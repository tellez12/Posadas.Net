using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Posadas.Domain.EF;
using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using Posadas.WebUI.ViewModels;
using Posadas.WebUI.ViewModels.Posadas;
using System.IO;
using Posadas.Utils;
using Posadas.WebUI.Utils;

namespace Posadas.WebUI.Controllers
{
    public class PosadasController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        public PosadasController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /Posada/

        public ActionResult Index(int page = 1)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Busqueda(string query="", int page = 0)
        {

            var pagingInfo = new PagingInfo(page, unitOfWork.PosadaRepository.Get().Count());
            query = query.ToLowerInvariant();
            ViewBag.pagingInfo = pagingInfo;
            //Email.SendSimpleMessage("MyMessage");
            return
                View(
                    unitOfWork.PosadaRepository.Get(includeProperties: "Estado,Lugar")
                    .Where(p => p.Nombre.ToLowerInvariant().Contains(query) ||
                        p.Estado.Nombre.ToLowerInvariant().Contains(query) ||
                        p.Lugar.Nombre.ToLowerInvariant().Contains(query))

                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * pagingInfo.ItemsPerPage)
                    .Take(pagingInfo.ItemsPerPage));


        }

        public ActionResult Listado(int page = 1)
        {
            var pagingInfo = new PagingInfo(page, unitOfWork.PosadaRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return
                View(
                    unitOfWork.PosadaRepository.Get(includeProperties: "Estado,Lugar")
                        .OrderBy(p => p.Id)
                        .Skip((page - 1) * pagingInfo.ItemsPerPage)
                        .Take(pagingInfo.ItemsPerPage));
        }

        //
        // GET: /Posada/Details/5

        public ActionResult Details(int id = 0)
        {
            var posada = unitOfWork.PosadaRepository.GetById(id, "Estado,Habitaciones,Habitaciones.Tipo");
            if (posada == null)
            {

                return HttpNotFound();
            }
            var posadaViewModel = Mapper.Map<Posada, PosadasViewModel>(posada);
            SetViewBag(posada);
            return View(posadaViewModel);
        }

        //
        // GET: /Posada/Create


        [Authorize]
        public ActionResult Create()
        {
            //ViewBag.Habitaciones = GetHabitacionesList();
            var posada = new Posada { Habitaciones = GetHabitacionesList(), Caracteristicas = new List<CaracteristicasPosadas>() };
            SetViewBag(posada);
            var posadasViewModel = Mapper.Map<Posada, PosadasViewModel>(posada);
            posadasViewModel.Estados = new SelectList(unitOfWork.EstadoRepository.Get(), "Id", "Nombre");

            return View(posadasViewModel);
        }

        private void SetViewBag(Posada posada)
        {
            List<Caracteristica> caracteristicas = unitOfWork.CaracteristicaRepository.Get().ToList();
            List<Caracteristica> selectedCaracteristicas =
                caracteristicas.Where(
                    c => posada.Caracteristicas.Select(cp => cp.CaracteristicaId).Contains(c.Id)).ToList();
            //List<Caracteristica> availableCaracteristicas =
            //    caracteristicas.Where(c => !selectedCaracteristicas.Contains(c)).ToList();

            ViewBag.caracteristicas = caracteristicas;
            ViewBag.selectedCaracteristicas = selectedCaracteristicas;
        }

        private List<HabitacionesPosada> GetHabitacionesList()
        {
            var tipoHabitaciones = unitOfWork.TipoHabitacionRepository.Get();
            return tipoHabitaciones.Select(tipoHabitacion => new HabitacionesPosada() { Tipo = tipoHabitacion, TipoHabitacionId = tipoHabitacion.Id }).ToList();
        }

        //
        // POST: /Posada/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(PosadasViewModel posadaViewModel)
        {
            if (ModelState.IsValid)
            {
                var posada = Mapper.Map<PosadasViewModel, Posada>(posadaViewModel);
                posada.UserId = User.Identity.GetUserId();
                posada.Caracteristicas = new List<CaracteristicasPosadas>();

                if (posadaViewModel.CaracteristicasId != null)
                {
                    foreach (var caracteristicaId in posadaViewModel.CaracteristicasId)
                    {
                        posada.Caracteristicas.Add(new CaracteristicasPosadas() { CaracteristicaId = caracteristicaId });
                    }
                }

                if (posada.LugarId == -1)//Seleccionaron otro 
                {
                    posada.LugarId = null;
                    posada.Misc = posadaViewModel.OtroLugar;
                }




                unitOfWork.PosadaRepository.Insert(posada);
                unitOfWork.Save();
                //Store this path somewhere else.
                var root = Server.MapPath(Constantes.PosadasBase + posada.Id + "/");
                var fotosList = new List<FotosPosada>();
                foreach (var item in posadaViewModel.FotosModels)
                {
                    if (item.FileBase != null)
                    {
                        string ext = Path.GetExtension(item.FileBase.FileName);
                        var fotoPosada = new FotosPosada();
                        fotoPosada.Alt = item.Alt;
                        fotoPosada.PosadaId = posada.Id;
                        fotoPosada.Ruta = Guid.NewGuid() + ext;
                        Directory.CreateDirectory(root);
                        item.FileBase.SaveAs(root + fotoPosada.Ruta);
                        fotosList.Add(fotoPosada);
                    }
                }
                unitOfWork.FotosPosadaRepository.Insert(fotosList);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(posadaViewModel);
        }

        //
        // GET: /Posada/Edit/5

        public ActionResult Edit(int id = 0)
        {

            Posada posada = unitOfWork.PosadaRepository.GetById(id, "Habitaciones,Habitaciones.Tipo");

            if (posada == null)
            {
                return HttpNotFound();
            }
            var posadasViewModel = Mapper.Map<Posada, PosadasViewModel>(posada);
            posadasViewModel.Estados = new SelectList(unitOfWork.EstadoRepository.Get(), "Id", "Nombre", posada.EstadoId);
            if (posada.EstadoId != 0)
            {
                var lugares = unitOfWork.LugarRepository.Get().Where(l => l.EstadoId == posada.EstadoId).ToList();
                lugares.Add(new Lugar() { Id = -1, Nombre = "otro" });

                if (posada.LugarId == null)
                {
                    if (!String.IsNullOrEmpty(posada.Misc))
                    {
                        posada.LugarId = -1;

                    }
                    posadasViewModel.OtroLugar = posada.Misc;//Si se guarda mas informacion en Misc serializar
                }
                posadasViewModel.Lugares = new SelectList(lugares, "Id", "Nombre", posada.LugarId);
            }

            SetViewBag(posada);

            return View(posadasViewModel);
        }

        //
        // POST: /Posada/Edit/5

        [HttpPost]
        public ActionResult Edit(PosadasViewModel posadaViewModel)
        {
            if (ModelState.IsValid)
            {

                var posada = Mapper.Map<PosadasViewModel, Posada>(posadaViewModel);
                if (posadaViewModel.LugarId == -1)
                {
                    posada.LugarId = null;
                    posada.Misc = posadaViewModel.OtroLugar;

                }


                //store in the viewModel?
                var oldCaracteristicas =
                    unitOfWork.CaracteristicasPosadasRepository.Get(p => p.PosadaId == posada.Id).ToList();
                //posada.Caracteristicas = oldCaracteristicas;
                if (posadaViewModel.CaracteristicasId == null)
                {
                    posadaViewModel.CaracteristicasId = new int[0];
                }
                var remove = oldCaracteristicas.Where(x => !posadaViewModel.CaracteristicasId.Contains(x.CaracteristicaId)).ToList();
                unitOfWork.CaracteristicasPosadasRepository.Delete(remove);
                var addIds = posadaViewModel.CaracteristicasId.Where(x => !oldCaracteristicas.Select(c => c.CaracteristicaId).Contains(x)).ToArray();


                foreach (var caracteristicaId in addIds)
                {
                    unitOfWork.CaracteristicasPosadasRepository.Insert(new CaracteristicasPosadas() { PosadaId = posada.Id, CaracteristicaId = caracteristicaId });
                }
                unitOfWork.PosadaRepository.Update(posada);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(posadaViewModel);
        }

        //
        // GET: /Posada/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Posada posada = unitOfWork.PosadaRepository.GetById(id);

            if (posada == null)
            {
                return HttpNotFound();
            }
            return View(posada);
        }

        //
        // POST: /Posada/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.PosadaRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}

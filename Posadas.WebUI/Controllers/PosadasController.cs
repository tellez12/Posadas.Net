using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Posadas.Domain.EF;
using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using Posadas.WebUI.ViewModels;

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
            PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.PosadaRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return
                View(
                    unitOfWork.PosadaRepository.Get()
                        .OrderBy(p => p.Id)
                        .Skip((page - 1)*pagingInfo.ItemsPerPage)
                        .Take(pagingInfo.ItemsPerPage));
        }

        //
        // GET: /Posada/Details/5

        public ActionResult Details(int id = 0)
        {
            Posada posada = unitOfWork.PosadaRepository.GetById(id);
            if (posada == null)
            {
                return HttpNotFound();
            }
            return View(posada);
        }

        //
        // GET: /Posada/Create

        public ActionResult Create()
        {
            //ViewBag.Habitaciones = GetHabitacionesList();
            var posada = new Posada {Habitaciones = GetHabitacionesList()};
            return View(posada);
        }

        private List<HabitacionesPosada> GetHabitacionesList()
        {
            var tipoHabitaciones = unitOfWork.TipoHabitacionRepository.Get();
            return tipoHabitaciones.Select(tipoHabitacion => new HabitacionesPosada() 
            {Tipo = tipoHabitacion, TipoHabitacionId = tipoHabitacion.Id}).ToList();
        }

        //
        // POST: /Posada/Create

        [HttpPost]
        public ActionResult Create(Posada posada)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PosadaRepository.Insert(posada);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(posada);
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

            return View(posada);
        }

        //
        // POST: /Posada/Edit/5

        [HttpPost]
        public ActionResult Edit(Posada posada)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PosadaRepository.Update(posada);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(posada);
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

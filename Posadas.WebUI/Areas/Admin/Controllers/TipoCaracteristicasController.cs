using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Posadas.Domain.EF;
using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using Posadas.WebUI.ViewModels;

namespace Posadas.WebUI.Areas.Admin.Controllers
{
    public class TipoCaracteristicasController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        public TipoCaracteristicasController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /TipoCaracteristica/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.TipoCaracteristicaRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return
                View(
                    unitOfWork.TipoCaracteristicaRepository.Get()
                        .OrderBy(p => p.Id)
                        .Skip((page - 1)*pagingInfo.ItemsPerPage)
                        .Take(pagingInfo.ItemsPerPage));
        }

        //
        // GET: /TipoCaracteristica/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoCaracteristica tipo = unitOfWork.TipoCaracteristicaRepository.GetById(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        //
        // GET: /TipoCaracteristica/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoCaracteristica/Create

        [HttpPost]
        public ActionResult Create(TipoCaracteristica tipo)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TipoCaracteristicaRepository.Insert(tipo);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(tipo);
        }

        //
        // GET: /TipoCaracteristica/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoCaracteristica tipo = unitOfWork.TipoCaracteristicaRepository.GetById(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }

            return View(tipo);
        }

        //
        // POST: /TipoCaracteristica/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoCaracteristica tipo)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TipoCaracteristicaRepository.Update(tipo);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(tipo);
        }

        //
        // GET: /TipoCaracteristica/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoCaracteristica tipo = unitOfWork.TipoCaracteristicaRepository.GetById(id);

            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        //
        // POST: /TipoCaracteristica/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.TipoCaracteristicaRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}

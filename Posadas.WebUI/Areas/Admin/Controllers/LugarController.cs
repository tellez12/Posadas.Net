using System.Linq;
using System.Web.Mvc;
using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using Posadas.WebUI.ViewModels;

namespace Posadas.WebUI.Areas.Admin.Controllers
{
    public class LugaresController : BaseAdminController
    {

        private readonly IUnitOfWork unitOfWork;

        public LugaresController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /Lugar/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.LugarRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return
                View(
                    unitOfWork.LugarRepository.Get()
                        .OrderBy(p => p.Id)
                        .Skip((page - 1)*pagingInfo.ItemsPerPage)
                        .Take(pagingInfo.ItemsPerPage));
        }

        //
        // GET: /Lugar/Details/5

        public ActionResult Details(int id = 0)
        {
            Lugar lugar = unitOfWork.LugarRepository.GetById(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        //
        // GET: /Lugar/Create

        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(unitOfWork.EstadoRepository.Get(), "Id", "Nombre");
            return View();
        }

        //
        // POST: /Lugar/Create

        [HttpPost]
        public ActionResult Create(Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.LugarRepository.Insert(lugar);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(lugar);
        }

        //
        // GET: /Lugar/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Lugar lugar = unitOfWork.LugarRepository.GetById(id);
            ViewBag.EstadoId = new SelectList(unitOfWork.EstadoRepository.Get(), "Id", "Nombre",lugar.EstadoId);
            if (lugar == null)
            {
                return HttpNotFound();
            }

            return View(lugar);
        }

        //
        // POST: /Lugar/Edit/5

        [HttpPost]
        public ActionResult Edit(Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.LugarRepository.Update(lugar);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(lugar);
        }

        //
        // GET: /Lugar/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Lugar lugar = unitOfWork.LugarRepository.GetById(id);

            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        //
        // POST: /Lugar/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.LugarRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}

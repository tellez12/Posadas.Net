using System.Linq;
using System.Web.Mvc;
using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using Posadas.WebUI.ViewModels;

namespace Posadas.WebUI.Areas.Admin.Controllers
{
    public class TipoHabitacionesController : BaseAdminController
    {


        private readonly IUnitOfWork unitOfWork;

        public TipoHabitacionesController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /TipoHabitacion/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.TipoHabitacionRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return
                View(
                    unitOfWork.TipoHabitacionRepository.Get()
                        .OrderBy(p => p.Id)
                        .Skip((page - 1)*pagingInfo.ItemsPerPage)
                        .Take(pagingInfo.ItemsPerPage));
        }

        //
        // GET: /TipoHabitacion/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoHabitacion tipoHabitacion = unitOfWork.TipoHabitacionRepository.GetById(id);
            if (tipoHabitacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoHabitacion);
        }

        //
        // GET: /TipoHabitacion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoHabitacion/Create

        [HttpPost]
        public ActionResult Create(TipoHabitacion tipoHabitacion)
        {
            if (!ModelState.IsValid) return View(tipoHabitacion);
            unitOfWork.TipoHabitacionRepository.Insert(tipoHabitacion);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //
        // GET: /TipoHabitacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoHabitacion tipoHabitacion = unitOfWork.TipoHabitacionRepository.GetById(id);
            if (tipoHabitacion == null)
            {
                return HttpNotFound();
            }

            return View(tipoHabitacion);
        }

        //
        // POST: /TipoHabitacion/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoHabitacion tipoHabitacion)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TipoHabitacionRepository.Update(tipoHabitacion);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(tipoHabitacion);
        }

        //
        // GET: /TipoHabitacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoHabitacion tipoHabitacion = unitOfWork.TipoHabitacionRepository.GetById(id);

            if (tipoHabitacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoHabitacion);
        }

        //
        // POST: /TipoHabitacion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.TipoHabitacionRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}

using System.Linq;
using System.Web.Mvc;
using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using Posadas.WebUI.ViewModels;

namespace Posadas.WebUI.Areas.Admin.Controllers
{
    public class EstadosController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        public EstadosController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /Estado/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.EstadoRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return
                View(
                    unitOfWork.EstadoRepository.Get()
                        .OrderBy(p => p.Id)
                        .Skip((page - 1)*pagingInfo.ItemsPerPage)
                        .Take(pagingInfo.ItemsPerPage));
        }

        //
        // GET: /Estado/Details/5

        public ActionResult Details(int id = 0)
        {
            Estado estado = unitOfWork.EstadoRepository.GetById(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        //
        // GET: /Estado/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Estado/Create

        [HttpPost]
        public ActionResult Create(Estado estado)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EstadoRepository.Insert(estado);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(estado);
        }

        //
        // GET: /Estado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Estado estado = unitOfWork.EstadoRepository.GetById(id);
            if (estado == null)
            {
                return HttpNotFound();
            }

            return View(estado);
        }

        //
        // POST: /Estado/Edit/5

        [HttpPost]
        public ActionResult Edit(Estado estado)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EstadoRepository.Update(estado);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(estado);
        }

        //
        // GET: /Estado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Estado estado = unitOfWork.EstadoRepository.GetById(id);

            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        //
        // POST: /Estado/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.EstadoRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}

using System.Linq;
using System.Web.Mvc;
using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using Posadas.WebUI.ViewModels;

namespace Posadas.WebUI.Areas.Admin.Controllers
{
	public class CaracteristicasController : Controller
	{

		private readonly IUnitOfWork unitOfWork;

		public CaracteristicasController(IUnitOfWork myUnitOfWork)
		{
			this.unitOfWork = myUnitOfWork;
		}

		//
		// GET: /Caracteristica/

		public ActionResult Index(int page = 1)
		{
			PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.CaracteristicaRepository.Get().Count());

			ViewBag.pagingInfo = pagingInfo;
			return
				View(
					unitOfWork.CaracteristicaRepository.Get()
						.OrderBy(p => p.Id)
						.Skip((page - 1)*pagingInfo.ItemsPerPage)
						.Take(pagingInfo.ItemsPerPage));
		}

		//
		// GET: /Caracteristica/Details/5

		public ActionResult Details(int id = 0)
		{
			Caracteristica caracteristica = unitOfWork.CaracteristicaRepository.GetById(id);
			if (caracteristica == null)
			{
				return HttpNotFound();
			}
			return View(caracteristica);
		}

		//
		// GET: /Caracteristica/Create

		public ActionResult Create()
		{
			ViewBag.TipoCaracteristicaId = new SelectList(unitOfWork.TipoCaracteristicaRepository.Get(), "Id", "Nombre");
	
			return View();
		}

		//
		// POST: /Caracteristica/Create

		[HttpPost]
		public ActionResult Create(Caracteristica caracteristica)
		{
			if (ModelState.IsValid)
			{
				unitOfWork.CaracteristicaRepository.Insert(caracteristica);
				unitOfWork.Save();
				return RedirectToAction("Index");
			}

			return View(caracteristica);
		}

		//
		// GET: /Caracteristica/Edit/5

		public ActionResult Edit(int id = 0)
		{
			Caracteristica caracteristica = unitOfWork.CaracteristicaRepository.GetById(id);
			ViewBag.TipoCaracteristicaId = new SelectList(unitOfWork.TipoCaracteristicaRepository.Get(), "Id", "Nombre", caracteristica.TipoCaracteristicaId);
			if (caracteristica == null)
			{
				return HttpNotFound();
			}

			return View(caracteristica);
		}

		//
		// POST: /Caracteristica/Edit/5

		[HttpPost]
		public ActionResult Edit(Caracteristica caracteristica)
		{
			if (ModelState.IsValid)
			{
				unitOfWork.CaracteristicaRepository.Update(caracteristica);
				unitOfWork.Save();
				return RedirectToAction("Index");
			}
	
			return View(caracteristica);
		}

		//
		// GET: /Caracteristica/Delete/5

		public ActionResult Delete(int id = 0)
		{
			Caracteristica caracteristica = unitOfWork.CaracteristicaRepository.GetById(id);

			if (caracteristica == null)
			{
				return HttpNotFound();
			}
			return View(caracteristica);
		}

		//
		// POST: /Caracteristica/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			unitOfWork.CaracteristicaRepository.Delete(id);
			return RedirectToAction("Index");
		}

	}
}

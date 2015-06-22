using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using Posadas.Utils;
using Posadas.WebUI.ViewModels;
using Posadas.WebUI.Utils;

namespace Posadas.WebUI.Areas.Admin.Controllers
{
	public class CaracteristicasController : BaseAdminController
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
		public ActionResult Create(Caracteristica caracteristica, HttpPostedFileBase imageUpload)
		{
			if (ModelState.IsValid)
			{
                if (imageUpload != null)
                {
                    string filename = caracteristica.Nombre + "-" +System.IO.Path.GetFileName(imageUpload.FileName);
                    var uploadResult =CloudinaryService.UploadFile(filename, imageUpload.InputStream,"Caracteristicas","Caracteristicas");
                    caracteristica.Imagen = uploadResult.Url;
                    caracteristica.ImagenPublicId = uploadResult.PublicId;
                    //caracteristica.Imagen = filename;
                    //////Store this path somewhere else.
                    //var root = Server.MapPath(Constantes.CaracteristicasBase);
                    //Directory.CreateDirectory(root);
                    //imageUpload.SaveAs(root + caracteristica.Imagen);
                }

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
				if (caracteristica == null)
			{
				return HttpNotFound();
			}
                ViewBag.TipoCaracteristicaId = new SelectList(unitOfWork.TipoCaracteristicaRepository.Get(), "Id", "Nombre", caracteristica.TipoCaracteristicaId);
		

			return View(caracteristica);
		}

		//
		// POST: /Caracteristica/Edit/5

		[HttpPost]
        public ActionResult Edit(Caracteristica caracteristica, HttpPostedFileBase imageUpload)
		{
			if (ModelState.IsValid)
			{
                if (imageUpload != null)
                {
                    string filename = System.IO.Path.GetFileName(imageUpload.FileName);
                    caracteristica.Imagen = caracteristica.Nombre + "-" + filename;
                    var root = Server.MapPath(Constantes.CaracteristicasBase);
                    Directory.CreateDirectory(root);
                    imageUpload.SaveAs(root + caracteristica.Imagen);
                }

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
            unitOfWork.Save();
			return RedirectToAction("Index");
		}

	}
}

using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using Posadas.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Posadas.WebUI.ViewModels.Posadas;
using AutoMapper;


namespace Posadas.WebUI.Api
{
    public class PosadasController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public PosadasController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //TODO: Fix this to use the Dependency Injection
        public PosadasController()
        {
            this.unitOfWork = new EFUnitOfWork();
        }

        // GET: api/Test
        public IEnumerable<PosadasViewModel> Get(int page=0)
        {
            PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.PosadaRepository.Get().Count());
            var posadas =
               
                    unitOfWork.PosadaRepository.Get(includeProperties: "Estado")
                        .OrderBy(p => p.Id)
                        .Skip((page - 1) * pagingInfo.ItemsPerPage)
                        .Take(pagingInfo.ItemsPerPage).Select(p=> Mapper.Map<Posada, PosadasViewModel>(p));

            return posadas;
        }

    }
}

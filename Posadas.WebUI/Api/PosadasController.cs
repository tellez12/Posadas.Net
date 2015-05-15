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
using Posadas.WebUI.Api.Models;


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
        public IEnumerable<PosadasApiViewModel> Get(int page=0)
        {
            PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.PosadaRepository.Get().Count());
            var posadas =

                    unitOfWork.PosadaRepository.Get(includeProperties: "Fotos,Estado")
                        .OrderBy(p => p.Id)
                        .Skip((page - 1) * pagingInfo.ItemsPerPage)
                        .Take(pagingInfo.ItemsPerPage)
                        .Select(p=> new PosadasApiViewModel(p));

            return posadas;
        }

        [Route("api/Estado/{nombreEstado}/posadas")]
        public IEnumerable<PosadasApiViewModel> GetPorEstado(string nombreEstado)
        {
            //PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.PosadaRepository.Get().Count());
            var posadas =

                    unitOfWork.PosadaRepository.Get(includeProperties: "Fotos,Estado")
                    .Where(p=>p.Estado!=null && p.Estado.Nombre.ToLower()==nombreEstado.ToLower())
                        .OrderBy(p => p.Id)
                //.Skip((page - 1) * pagingInfo.ItemsPerPage)
                //.Take(pagingInfo.ItemsPerPage)
                        .Select(p => new PosadasApiViewModel(p));

            return posadas;
        }

        [Route("api/Lugar/{nombreLugar}/posadas")]
        public IEnumerable<PosadasApiViewModel> GetPorLugar(string nombreLugar)
        {
            //PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.PosadaRepository.Get().Count());
            var posadas =

                    unitOfWork.PosadaRepository.Get(includeProperties: "Fotos,Estado,Lugar")
                    .Where(p => p.Lugar != null && p.Lugar.Nombre.ToLower() == nombreLugar.ToLower())
                        .OrderBy(p => p.Id)
                //.Skip((page - 1) * pagingInfo.ItemsPerPage)
                //.Take(pagingInfo.ItemsPerPage)
                        .Select(p => new PosadasApiViewModel(p));

            return posadas;
        }

    }
}

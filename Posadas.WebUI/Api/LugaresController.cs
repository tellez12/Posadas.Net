using Posadas.Domain.Entities;
using Posadas.Domain.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Posadas.WebUI.Api
{
    public class LugaresController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public LugaresController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //TODO: Fix this to use the Dependency Injection
        public LugaresController()
        {
            this.unitOfWork = new EFUnitOfWork();
        }

        // GET: api/Lugares/5
        public IEnumerable<Lugar> Get(int id)
        {
            var lugares = unitOfWork.LugarRepository.Get().Where(l => l.EstadoId == id);
            return lugares;
        }

    }
}

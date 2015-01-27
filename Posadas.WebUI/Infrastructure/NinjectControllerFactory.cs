using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Posadas.Domain.UOW;

namespace Posadas.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUnitOfWork>().To<EFUnitOfWork>();
            // AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
           requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }
    }
}
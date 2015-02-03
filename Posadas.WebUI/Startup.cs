using AutoMapper;
using Microsoft.Owin;
using Owin;
using Posadas.Domain.Entities;
using Posadas.WebUI.ViewModels.Posadas;

[assembly: OwinStartupAttribute(typeof(Posadas.WebUI.Startup))]
namespace Posadas.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            InitializeAutoMapper();
        }

        private void InitializeAutoMapper()
        {
            Mapper.CreateMap<Posada, PosadasViewModel>();
            Mapper.CreateMap<PosadasViewModel, Posada>();
        }
    }
}

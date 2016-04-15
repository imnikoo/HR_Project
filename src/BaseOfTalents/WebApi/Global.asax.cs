using Autofac;
using Autofac.Integration.WebApi;
using Data.EFData.Repositories;
using Domain.Repositories;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public object Assemby { get; private set; }
        public object DependencyResolver { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var builder = new ContainerBuilder();

            builder.RegisterType<EFVacancyRepository>().As<IVacancyRepository>();
            builder.RegisterType<EFCandidateRepository>().As<ICandidateRepository>();
            builder.RegisterType<EFSocialNetworkRepository>().As<ISocialNetworkRepository>();
            builder.RegisterType<EFCityRepository>().As<ICityRepository>();
            builder.RegisterType<EFSkillRepository>().As<ISkillRepository>();
            builder.RegisterType<EFTeamRepository>().As<ITeamRepository>();
            builder.RegisterType<EFExperienceRepository>().As<IExperienceRepository>();
            builder.RegisterType<EFCountryRepository>().As<ICountryRepository>();
            builder.RegisterType<EFLanguageRepository>().As<ILanguageRepository>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}

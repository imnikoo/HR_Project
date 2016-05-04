using Autofac;
using Autofac.Integration.WebApi;
using Data.EFData;
using Data.EFData.Repositories;
using Data.Infrastructure;
using Domain.Repositories;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Domain.Entities;

namespace UnitTest
{
    public class AutofacTestApiConfiguration
    {
        public static Autofac.IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }
        public static void Initialize(HttpConfiguration config, Autofac.IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static Autofac.IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<EFCandidateRepository>()
                .As<IRepository<Candidate>>()
                .InstancePerRequest();

            builder.RegisterType<EFVacancyRepository>()
                .As<IRepository<Vacancy>>()
                .InstancePerRequest();

            builder.RegisterType<SQLiteDbFactory>()
                .As<IDbFactory>()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            builder.RegisterType<DataRepositoryFactory>()
                .As<IDataRepositoryFactory>()
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(EFBaseEntityRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerRequest();

            Container = builder.Build();
            return Container;

        }
    }
}
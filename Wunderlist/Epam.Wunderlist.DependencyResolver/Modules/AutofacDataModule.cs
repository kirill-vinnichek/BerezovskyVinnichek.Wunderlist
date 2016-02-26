using Autofac;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.DataAccess.MsSql.Infrastructure;
using Epam.Wunderlist.DataAccess.MsSql.Repositories;

namespace Epam.Wunderlist.DependencyResolver.Modules
{
   public class AutofacDataModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            base.Load(builder);
        }
    }
}

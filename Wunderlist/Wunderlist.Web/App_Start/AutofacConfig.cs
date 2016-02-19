using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Data.Repositories;
using Wunderlist.Service.Services;
using Wunderlist.Web.Infrastructure;
using Wunderlist.Web.Models;

namespace Wunderlist.Web
{
    public static class AutofacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<CustomUserStore>().As<IUserStore<OwinUser>>().InstancePerRequest();
            builder.RegisterType<CustomRoleStore>().As<IRoleStore<OwinRole>>().InstancePerRequest();
            builder.RegisterType<UserManager<OwinUser>>().InstancePerRequest();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using System.Reflection;
using System.Web.Mvc;
using Wunderlist.Service.Core;
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
            builder.RegisterFilterProvider();
            builder.RegisterModule(new AutofacServiceModule());

            builder.RegisterType<CustomUserStore>().As<IUserStore<OwinUser>>().InstancePerRequest();
            builder.RegisterType<CustomRoleStore>().As<IRoleStore<OwinRole>>().InstancePerRequest();
            builder.RegisterType<UserManager<OwinUser>>().InstancePerRequest();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
using Autofac;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Services.Services;

namespace Epam.Wunderlist.DependencyResolver.Modules
{
   public class AutofacServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            base.Load(builder);
        }
    }
}

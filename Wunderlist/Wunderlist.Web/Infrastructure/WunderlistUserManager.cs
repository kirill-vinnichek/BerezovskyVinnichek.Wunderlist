using Epam.Wunderlist.Web.Models;
using Microsoft.AspNet.Identity;

namespace Epam.Wunderlist.Web.Infrastructure
{
    public class WunderlistUserManager : UserManager<OwinUser,int>
    {
        public WunderlistUserManager(IUserStore<OwinUser, int> store) : base(store)
        {
            UserValidator = new UserValidator<OwinUser,int>(this)
            {
                RequireUniqueEmail = true
            };
        }
    }
}
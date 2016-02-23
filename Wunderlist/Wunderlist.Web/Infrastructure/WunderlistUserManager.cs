using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wunderlist.Web.Models;

namespace Wunderlist.Web.Infrastructure
{
    public class WunderlistUserManager : UserManager<OwinUser>
    {
        public WunderlistUserManager(IUserStore<OwinUser> store) : base(store)
        {
            UserValidator = new UserValidator<OwinUser>(this)
            {
                RequireUniqueEmail = true
            };
        }
    }
}
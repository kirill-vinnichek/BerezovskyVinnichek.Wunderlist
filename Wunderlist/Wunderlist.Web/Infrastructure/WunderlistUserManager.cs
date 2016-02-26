using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wunderlist.Web.Models;

namespace Wunderlist.Web.Infrastructure
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
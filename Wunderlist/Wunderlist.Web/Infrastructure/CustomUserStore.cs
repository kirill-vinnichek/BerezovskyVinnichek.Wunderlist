using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.Web.Infrastructure
{
    public class CustomUserStore:IUserStore<User>, IUserPasswordStore<User>
    {

    }
}
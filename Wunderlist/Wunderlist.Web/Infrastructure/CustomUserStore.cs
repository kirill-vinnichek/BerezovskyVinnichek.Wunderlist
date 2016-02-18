using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wunderlist.Models;
using System.Threading.Tasks;
using Wunderlist.Web.Models;

namespace Wunderlist.Web.Infrastructure
{
    public class CustomUserStore : IUserStore<OwinUser>, IUserPasswordStore<OwinUser>
    {



        #region Not Implemented


        #endregion
        public System.Threading.Tasks.Task CreateAsync(OwinUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync(OwinUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<OwinUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<OwinUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(OwinUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(OwinUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task SetPasswordHashAsync(OwinUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(OwinUser user)
        {
            throw new NotImplementedException();
        }
    }
}
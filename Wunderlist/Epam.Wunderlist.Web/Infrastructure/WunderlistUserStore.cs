using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.Web.Infrastructure
{
    public class WunderlistUserStore : IUserStore<OwinUser,int>, IUserPasswordStore<OwinUser, int>, IUserEmailStore<OwinUser, int>
    {
        private readonly IUserService userService;
       

        public WunderlistUserStore(IUserService userService)
        {
            this.userService = userService;           
        }

        //TODO: Implement When Stas ends Services
        #region Not Implemented        

        public Task<bool> GetEmailConfirmedAsync(OwinUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(OwinUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }


        #endregion

        public System.Threading.Tasks.Task CreateAsync(OwinUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
           
            var u = Mapper.Map<User>(user);
            return Task.Run(() => userService.Add(u));

        }

        //We use authorization by email,that why we use email
        public Task<OwinUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("userName is null or empty");
            return Task.Run(() => Mapper.Map<OwinUser>(userService.GetByEmail(userName)));
        }

        public Task<OwinUser> FindByIdAsync(int userId)
        {           
            return Task.Run(() => Mapper.Map<OwinUser>(userService.GetById(userId)));
        }
        public Task<OwinUser> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("email is null or empty");
            return Task.Run(() => Mapper.Map<OwinUser>(userService.GetByEmail(email)));
        }

        public System.Threading.Tasks.Task UpdateAsync(OwinUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            var u = Mapper.Map<User>(user);
            return Task.Run(() => userService.Update(u));
        }

        public System.Threading.Tasks.Task DeleteAsync(OwinUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            var u = Mapper.Map<User>(user);
            return Task.Run(() => userService.Delete(u));
        }

        public Task<string> GetPasswordHashAsync(OwinUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            var password = userService.GetById(user.Id).UserPasswordHash;
            return Task.FromResult(password);
        }

        public Task<bool> HasPasswordAsync(OwinUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            var password = userService.GetById(user.Id).UserPasswordHash;
            return Task.FromResult(!string.IsNullOrEmpty(password));
        }

        public System.Threading.Tasks.Task SetPasswordHashAsync(OwinUser user, string passwordHash)
        {
            user.UserPasswordHash = passwordHash;
            return Task.FromResult<object>(null);
        }

        public Task<string> GetEmailAsync(OwinUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult(user.Email);
        }

        public Task SetEmailAsync(OwinUser user, string email)
        {
            user.Email = email;            
            return UpdateAsync(user);
        }

        public void Dispose()
        {

        }

        









       

       

      
       
    }
}
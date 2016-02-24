using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wunderlist.Web.Models;
using System.Threading.Tasks;
using AutoMapper;
using Wunderlist.Models;
using Wunderlist.Service.Interfaces;

namespace Wunderlist.Web.Infrastructure
{
    public class WunderlistRoleStore : IRoleStore<OwinRole,int>
    {

        private readonly IRoleService roleService;

        public WunderlistRoleStore(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public Task CreateAsync(OwinRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var r = Mapper.Map<Role>(role);
            return Task.Run(() => roleService.Add(r));
        }

        public Task DeleteAsync(OwinRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var r = Mapper.Map<Role>(role);
            return Task.Run(() => roleService.Delete(r));
        }

       

        public Task<OwinRole> FindByIdAsync(int roleId)
        {
            if (string.IsNullOrEmpty(roleId))
                throw new ArgumentException("roleId is null or empty");
            return Task.Run(() => Mapper.Map<OwinRole>(roleService.GetById(roleId)));
        }

        public Task<OwinRole> FindByNameAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new ArgumentException("roleName is null or empty");
            return Task.Run(() => Mapper.Map<OwinRole>(roleService.GetByName(roleName)));
        }

        public Task UpdateAsync(OwinRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var r = Mapper.Map<Role>(role);
            return Task.Run(() => roleService.Update(r));
        }

        public void Dispose()
        {

        }
    }
}
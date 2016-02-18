using System;
using AutoMapper;
using Wunderlist.Web.Models;
using Wunderlist.Models;

namespace Wunderlist.Web.Mapping
{
    public class ViewModelToDomainMappingProfile: AutoMapper.Profile
    {       
       
        protected override void Configure()
        {
            Mapper.CreateMap<OwinUser, User>();
            Mapper.CreateMap<OwinRole, Role>();
        }
    }
}
using AutoMapper;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Web.Models;

namespace Epam.Wunderlist.Web.Mapping
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
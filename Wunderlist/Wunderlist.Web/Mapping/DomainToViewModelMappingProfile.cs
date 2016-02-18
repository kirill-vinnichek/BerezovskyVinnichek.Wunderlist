using AutoMapper;
using Wunderlist.Models;
using Wunderlist.Web.Models;

namespace Wunderlist.Web.Mapping
{
    public class DomainToViewModelMappingProfile: AutoMapper.Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, OwinUser>();
            Mapper.CreateMap<Role, OwinRole>();
        }
    }
}
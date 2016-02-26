using AutoMapper;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Web.Models;

namespace Epam.Wunderlist.Web.Mapping
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
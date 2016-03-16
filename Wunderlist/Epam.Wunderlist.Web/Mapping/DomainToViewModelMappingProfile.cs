using AutoMapper;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Web.ViewModels;

namespace Epam.Wunderlist.Web.Mapping
{
    public class DomainToViewModelMappingProfile: AutoMapper.Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, OwinUser>();
            Mapper.CreateMap<Role, OwinRole>();
            Mapper.CreateMap<User, UserInfo>();
            Mapper.CreateMap<ToDoItemList, ToDoItemListViewModel>();
            Mapper.CreateMap<ToDoItem, ToDoItemViewModel>();
            Mapper.CreateMap<ToDoItemList, FilteredToDoItemList>();
        }
    }
}
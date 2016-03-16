using AutoMapper;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Web.ViewModels;

namespace Epam.Wunderlist.Web.Mapping
{
    public class ViewModelToDomainMappingProfile: AutoMapper.Profile
    {       
       
        protected override void Configure()
        {
            Mapper.CreateMap<OwinUser, User>();
            Mapper.CreateMap<OwinRole, Role>();
            Mapper.CreateMap<UserInfo, User>();
            Mapper.CreateMap<ToDoItemListViewModel, ToDoItemList>();
            Mapper.CreateMap<ToDoItemViewModel, ToDoItem>();
            Mapper.CreateMap<MarkedToDoItemList,ToDoItemList>();
        }
    }
}
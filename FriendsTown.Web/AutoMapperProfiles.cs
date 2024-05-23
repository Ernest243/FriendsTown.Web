using AutoMapper;
using FriendsTown.Services;
using FriendsTown.Web.Models;

namespace FriendsTown.Web
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<EventInputModel, DtoEventData>();
            CreateMap<DtoEventsWithOffers, EventListViewModel>();
        }
    }
}

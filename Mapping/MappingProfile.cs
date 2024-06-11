using AutoMapper;
using BookingMeeting.Resources;
using BookingMeeting.Models;
using BookingMeeting.Controllers;

namespace BookingMeeting.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Company, CompanyResource>();
            CreateMap<Meeting, MeetingResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<SystemUser, SystemUserResources>();


            CreateMap<CompanyResource, Company>();
            CreateMap<MeetingResource, Meeting>();
            CreateMap<RoomResource, Room>();
            CreateMap<SystemUserResources, SystemUser>();

            CreateMap<SaveCompanyResource, Company>();
            CreateMap<SaveMeetingResource, Meeting>();
            CreateMap<SaveRoomResource, Room>();
            CreateMap<SaveSystemUserResource, SystemUser>();
        }
        

    }
}

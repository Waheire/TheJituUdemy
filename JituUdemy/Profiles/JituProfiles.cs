using AutoMapper;
using JituUdemy.Entities;
using JituUdemy.Request;
using JituUdemy.Response;

namespace JituUdemy.Profiles
{
    public class JituProfiles : Profile
    {
        public JituProfiles()
        {
            CreateMap<AddUser, User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
        }
    }
}

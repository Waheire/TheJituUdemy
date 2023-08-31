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
            //User
            CreateMap<AddUser, User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();

            //Instructor
            CreateMap<AddUser, Instructor>().ReverseMap();
            CreateMap<UserResponse, Instructor>().ReverseMap();

            //Instructor
            CreateMap<AddCourse, Course>().ReverseMap();
            CreateMap<UpdateCourse, Course>().ReverseMap();
            CreateMap<CourseResponse, Course>().ReverseMap();
        }
    }
}

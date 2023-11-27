using AutoMapper;
using School.DTOs;
using School.Models;

namespace School.Config
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateTeacherDto, Teacher>();
            CreateMap<CreatePeriodDto, Period>();
        }
    }
}

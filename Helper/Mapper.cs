using AutoMapper;
using jobify_Backend.Dto.CompanyDtos;
using jobify_Backend.Dto.JobDtos;
using jobify_Backend.Dto.UserDtos;
using jobify_Backend.Models;

namespace jobify_Backend.Helper
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<User,GetUserDto>().ReverseMap();
            CreateMap<User,SignupDto>().ReverseMap();
            CreateMap<Job,GetJobDto>().ReverseMap();
            CreateMap<Job, CreateJobDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();

        }
    }
}

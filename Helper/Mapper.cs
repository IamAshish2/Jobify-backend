using AutoMapper;
using jobify_Backend.Dto;
using jobify_Backend.Dto.CompanyDtos;
using jobify_Backend.Models;

namespace jobify_Backend.Helper
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<User,GetUserDto>();
            CreateMap<GetUserDto,User>();
            CreateMap<Job,GetJobDto>();
            CreateMap<GetJobDto,Job>();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
        }
    }
}

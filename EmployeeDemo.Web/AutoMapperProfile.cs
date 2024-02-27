using AutoMapper;
using EmployeeDemo.Domain.Employee;
using EmployeeDemo.Web.Models;

namespace EmployeeDemo.Web
{
    public class AutoMapperProfile : Profile
    {       
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Skill_Name, opt => opt.MapFrom(src => string.Join(",", src.Skills.Select(x => x.skill_name))))
                .ForMember(dest => dest.skillList, opt => opt.MapFrom(src => src.Skills.Select(x => x.skill_name)));
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Skill, SkillDto>().ReverseMap();     
      }
    }
}

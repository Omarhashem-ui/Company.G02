using AutoMapper;
using Company.G02.DAL.Models;
using Company.G02.Mvc.Dtos;

namespace Company.G02.Mvc.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, CreateEmployeedto>().ReverseMap()
          .ForMember(d=>d.Name,o=>o.MapFrom(s=>s.EmpName));
        }
    }
}

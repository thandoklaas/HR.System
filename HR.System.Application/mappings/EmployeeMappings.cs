using AutoMapper;
using HR.System.Application.viewmodels;
using HR.System.Domain.entities;

namespace HR.System.Application.mappings
{
    public class EmployeeViewModelMappingProfile : Profile
    {

        public EmployeeViewModelMappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            //CreateMap<EmployeeViewModel, Employee>();
        }
    }

    public class EmployeeDbModelMappingProfile : Profile
    {
        protected  EmployeeDbModelMappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>();
        }
    }
}

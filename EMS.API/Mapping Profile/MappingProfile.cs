using AutoMapper;
using EMS.API.Dtos.Cities;
using EMS.API.Dtos.Country;
using EMS.API.Dtos.Departments;
using EMS.API.Entities.DB2_Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EMS.API.Mapping_Profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CountryCreateDto, Country>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Country, CountryReadDto>();
            CreateMap<CountryUpdateDto, Country>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<DepartmentCreateDto, Department>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Department, DepartmentReadDto>();
            CreateMap<DepartmentUpdateDto, Department>()
                .ForMember(opt => opt.Id, opt => opt.Ignore());

            CreateMap<CityCreateDto, City>()
                .ForMember(dest => dest.Id, Opt => Opt.Ignore());
            CreateMap<City, CityReadDto>();
            CreateMap<CityUpdateDto, City>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}

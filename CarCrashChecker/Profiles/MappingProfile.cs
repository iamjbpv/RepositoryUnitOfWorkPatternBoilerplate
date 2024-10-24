using AutoMapper;
using CarCrashChecker.Entities;
using CarCrashChecker.Models;
namespace CarCrashChecker.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarVm>().ReverseMap(); // Maps CarPlate to CarPlateDto and vice versa
        }
    }
}

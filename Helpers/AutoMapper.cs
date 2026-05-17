using AutoMapper;
using Clinic_Management_API.Dtos.DoctorDtos;
using Clinic_Management_API.Dtos.PatientDtos;

namespace Clinic_Management_API.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<CreatDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>();
            CreateMap<Dtos.PatientDtos.CreatPatientDto, Patient>();
            CreateMap<Dtos.PatientDtos.UpdatePatientDto, Patient>();


        }
    }
}

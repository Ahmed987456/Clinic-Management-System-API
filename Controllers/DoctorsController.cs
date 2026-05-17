using AutoMapper;
using Clinic_Management_API.Data;
using Clinic_Management_API.Dtos;
using Clinic_Management_API.Dtos.DoctorDtos;
using Clinic_Management_API.Services.DoctorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace Clinic_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        private readonly IDoctorService _doctorservice;
        private readonly IMapper mapper;

        public DoctorsController(IDoctorService doctorservice, IMapper mapper)
        {
            _doctorservice = doctorservice;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllASync()
        {
            var Doctors = await _doctorservice.GetAll();
            return Ok(Doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var doctor = await _doctorservice.GetById(id);
            if (doctor == null)
                return BadRequest($"No Doctor Found With Id {id}");
            return Ok(doctor);
        }
        [HttpPost]

        public async Task<IActionResult> CreatAsync([FromForm] CreatDoctorDto dto)
        {
            var doctor = mapper.Map<Doctor>(dto);
            _doctorservice.AddNewDoctor(doctor);
            return Ok(doctor);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateDoctorDto dto)
        {
            var doctor = await _doctorservice.GetById(id);
            if (doctor == null)
                return BadRequest($"No Doctor Found With Id {id}");
            var data = mapper.Map(dto,doctor);
            _doctorservice.UpdateDoctor(doctor);
            return Ok(doctor);
        }

        [HttpDelete]
        public async Task<IActionResult> DelteAsync(int id) 
        {
            var doctor = await _doctorservice.GetById(id);
            if (doctor == null)
                return BadRequest($"No Doctor Found With Id {id}");
              _doctorservice.DelteDoctor(doctor);
            return Ok(doctor);
        }
     //   [HttpGet]
     //   public async Task<IActionResult> GetAll() 
     //   {
     //       var egyptTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
     //       var doctors = await _context.Doctors.Include(s => s.Appointments).ThenInclude(s => s.Patient).ToListAsync();
     //       var result = doctors.Select(s => new DoctorsDto
     //{
     //    Id = s.Id,
     //    Name = s.Name,
     //    Specialization = s.Specialization,
     //    Email = s.Email,

        //    appointmets = s.Appointments.Select(a => new AppointmentDtos
        //    {
        //        Id = a.Id,
        //        AppointmentDate = TimeZoneInfo.ConvertTimeFromUtc(
        //               a.AppointmentDate,
        //               egyptTimeZone
        //           ),
        //        Status = a.Status,

        //        patient = new PatientDtos
        //        {
        //            PatientId = a.Patient.Id,
        //            Name = a.Patient.Name,
        //            Age = a.Patient.Age,
        //            PhoneNumber = a.Patient.PhoneNumber
        //        }
        //    }).ToList()
        //})
        //.ToList();
        //       return Ok(result);
        //   }
    }
}

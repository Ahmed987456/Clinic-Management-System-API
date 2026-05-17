using AutoMapper;
using Clinic_Management_API.Dtos.AppoientmentDtos;
using Clinic_Management_API.Enums;
using Clinic_Management_API.Helpers;
using Clinic_Management_API.Services.AppointmentServices;
using Clinic_Management_API.Services.DoctorServices;
using Clinic_Management_API.Services.PatientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

        private readonly IDoctorService doctorService;
        private readonly IPatientService patientService;
        private readonly IAppointmentService appointmentService;
        private readonly IMapper mapper;


        public AppointmentsController(IDoctorService doctorService, IPatientService patientService,IAppointmentService appointmentService, IMapper mapper)
        {
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.appointmentService = appointmentService;
            this.mapper = mapper;
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var appointent = await appointmentService.GetAll();
            return Ok(appointent);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var appointment = await appointmentService.GetById(id);
            if (appointment == null)
                return NotFound($"No Apoointment Booked With Id {id}");
            return Ok(appointment);
        }

        [HttpGet("doctorid/{id}")]
        public async Task<IActionResult> GetByDoctorID(int id)
        {
            var doctor = await doctorService.GetById(id);
            if (doctor == null)
                return NotFound("Not Doctros Found With This Id");
            var appoint = await appointmentService.GetAllByDoctorId(id);
            if (!appoint.Any())
                return NotFound("There are no available appointments for this doctor.");
            return Ok(appoint);
        }

        [HttpGet("patientid/{id}")]
        public async Task<IActionResult> GetByPatientID(int id)
        {
            var patient = await patientService.GetById(id);
            if (patient == null)
                return NotFound("Not Patients Found With This Id");
            var appoint = await appointmentService.GetAllByPatientId(id);
            if (!appoint.Any())
                return NotFound("There are no available appointments for this Patient.");
            return Ok(appoint);
        }


        [HttpGet("NumbersOfAppointments")]
        public async Task<IActionResult> GetNumberOfAppointemnts()
        {
            var appointments = await appointmentService.GetNumbersOfAppointemts();
            return Ok(appointments);
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromForm] CreatDto dto)
        {
            var utcDate = DateTimeHelper.ToUtc(dto.AppointmentDate);
            var doctor = await doctorService.GetById(dto.DoctorId);

            if (doctor == null)
                return BadRequest($"No Doctor Found With Id {dto.DoctorId}");

            var pstient = await patientService.GetById(dto.PatientId);

            if (pstient == null)
                return BadRequest($"No Patient Found With Id {dto.PatientId}");

            if (utcDate < DateTime.UtcNow)
                return BadRequest("Date must be in the future");

            var appointement = new Appointment
            {
                AppointmentDate = utcDate,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                Status = AppointmentStatus.Pending
            };

            var result = await appointmentService.CreatAppoientment(appointement);

            if (result == null)
                return BadRequest("the appointment isBooked");
            return Ok(new
            {
                result.Id,
                result.Status,
                result.AppointmentDate,
                result.DoctorId,
                result.PatientId,
                s = "Booked sacsued"
            });

        }

        #endregion

        #region Put

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatusAsync(int id, [FromForm] UpdateStatusDto dto) 
        {
         var appointment = await appointmentService.GetAppointmentEntityById(id);
         if(appointment == null)
                return NotFound($"Not appointament with This Id {id}");
           appointment.Status = dto.Status;
           await appointmentService.UpdateStatus(appointment);
           return Ok(new {
           appointment.Id,
           appointment.Status
           });
         
        }

        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentAsync(int id ) 
        {
          var appointment = await appointmentService.GetAppointmentEntityById(id);
            if (appointment == null)
                return NotFound($"Not appointament with This Id {id}");
         await  appointmentService.Deleteappointment(appointment);
            return Ok("Appointment deleted successfully");
        }
        #endregion
    }
}

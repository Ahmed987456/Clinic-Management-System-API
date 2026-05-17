
using AutoMapper;
using Clinic_Management_API.Dtos.PatientDtos;
using Clinic_Management_API.Services.PatientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            var patient = await _patientService.GetAll();
            return Ok(patient);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientService.GetById(id);
            if (patient == null)
                return NotFound($"Not Patient Found With Id {id}");
            return Ok(patient);
        }

        [HttpPost]

        public async Task<IActionResult> CreatAsync([FromForm] Dtos.PatientDtos.CreatPatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
           var result= await _patientService.Creat(patient);
            if (result == null)
                return BadRequest("Phone Number Already Exists");
            return Ok(result);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAsync(int id , [FromForm] UpdatePatientDto dto) 
        {
            var patient = await _patientService.GetById(id);
            if (patient == null)
                return NotFound($"Not Patient Found With Id {id}");
             _mapper.Map(dto, patient);
             var result = _patientService.Update(patient);
             if (result == null)
                return BadRequest("Phone Number Already Exists");
            return Ok(result);
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var patient = await _patientService.GetById(id);
            if (patient == null)
                return NotFound($"Not Patient Found With Id {id}");
            _patientService.Delete(patient);
            return Ok(patient);
        }

        [HttpGet("PatientsDeatils")]

        public async Task<IActionResult> GetAllPatientsAsync()
        {
            var patient = await _patientService.GetAllPatients();
            return Ok(patient);
        }
    }
}

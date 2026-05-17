using AutoMapper;
using Clinic_Management_API.Data;
using Clinic_Management_API.Dtos.AppoientmentDtos;
using Clinic_Management_API.Enums;
using Clinic_Management_API.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Management_API.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;
        public AppointmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        // Get Methods
        #region Get
        public async Task<IEnumerable<AppointmentDetails>> GetAll()
        {
            return await _context.Appointments
                  .Select(s => new AppointmentDetails
                  {
                      Id = s.Id,
                      DoctorName = s.Doctor.Name,
                        PatientName = s.Patient.Name,
                      Status = s.Status,
                      AppointmentDate = DateTimeHelper.ToEgyptTime(s.AppointmentDate)
                  })
                  .ToListAsync();
        }
        public async Task<AppointmentDetails?> GetById(int id)
        {
            var appointment = await _context.Appointments.
                   Include(s => s.Doctor)
                  .Include(s => s.Patient)
                  .FirstOrDefaultAsync(s => s.Id == id);
            if (appointment == null)
                return null;

            return new AppointmentDetails
            {
                Id = appointment.Id,
                DoctorName = appointment.Doctor.Name,
                PatientName = appointment.Patient.Name,
                AppointmentDate = DateTimeHelper.ToEgyptTime(appointment.AppointmentDate)
             ,
                Status = appointment.Status
            };
        }
        public async Task<IEnumerable<AppointmentDetails>> GetAllByDoctorId(int id)
        {
            return await _context.Appointments.Where(s => s.DoctorId == id)
                .Select(s => new AppointmentDetails
                {
                    Id = s.Id,
                    DoctorName = s.Doctor.Name,
                    PatientName = s.Patient.Name,
                    Status = s.Status,
                    AppointmentDate = DateTimeHelper.ToEgyptTime(s.AppointmentDate)
                })
                .ToListAsync();

        }
        public async Task<IEnumerable<AppointmentDetails>> GetAllByPatientId(int id)
        {
            return await _context.Appointments.Where(s => s.PatientId == id)
                  .Select(s => new AppointmentDetails
                  {
                      Id = s.Id,
                      DoctorName = s.Doctor.Name,
                      PatientName = s.Patient.Name,
                      Status = s.Status,
                      AppointmentDate = DateTimeHelper.ToEgyptTime(s.AppointmentDate)
                  })
                  .ToListAsync();
        }
        public async Task<IEnumerable<AppointementsCounts>> GetNumbersOfAppointemts()
        {
            return await _context.Appointments
                .Include(s => s.Doctor).GroupBy(s => new { s.DoctorId, s.Doctor.Name })
                 .Select(s => new AppointementsCounts
                 {
                     DoctorID = s.Key.DoctorId,
                     Name = s.Key.Name,
                     Count = s.Count()
                 })
               .ToListAsync();
        }
        public async Task<Appointment?> GetAppointmentEntityById(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        }
        #endregion

        // Post Mehods
        #region Creat
        public async Task<Appointment> CreatAppoientment(Appointment appointment )
        {
            var isBooked = await _context.Appointments.AnyAsync(a => a.DoctorId == appointment.DoctorId && a.AppointmentDate == appointment.AppointmentDate);
               if (isBooked) return null;
            appointment.Status = AppointmentStatus.Pending;
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;

        }
        #endregion

        // Update Methods
        #region Update
        public async Task<Appointment> UpdateStatus(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        #endregion

        // Delete Methods
        #region Delete
        public async Task<Appointment> Deleteappointment(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        #endregion
    }
}

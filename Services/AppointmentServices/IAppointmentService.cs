using Clinic_Management_API.Dtos.AppoientmentDtos;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_API.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<Appointment> CreatAppoientment(Appointment appointment);

        Task<IEnumerable<AppointmentDetails>> GetAll();

        Task<AppointmentDetails?> GetById(int id);

        Task<Appointment?> GetAppointmentEntityById(int id);

        Task <Appointment> UpdateStatus(Appointment appointment);

        Task<Appointment> Deleteappointment(Appointment appointment);

        Task<IEnumerable<AppointmentDetails>> GetAllByDoctorId(int id);

        Task<IEnumerable<AppointmentDetails>> GetAllByPatientId(int id);

        Task<IEnumerable<AppointementsCounts>> GetNumbersOfAppointemts();

    }
}

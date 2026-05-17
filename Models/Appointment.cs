using Clinic_Management_API.Enums;

namespace Clinic_Management_API.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus Status { get; set; }

        public Patient Patient { get; set; }    

        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }

        public int DoctorId { get; set; }

    }
}

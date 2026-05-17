    using Clinic_Management_API.Enums;

namespace Clinic_Management_API.Dtos.AppoientmentDtos
{
    public class AppointmentDetails
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus Status { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }
    }
}

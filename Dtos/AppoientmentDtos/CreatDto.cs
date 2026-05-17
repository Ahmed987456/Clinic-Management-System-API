using Clinic_Management_API.Enums;

namespace Clinic_Management_API.Dtos.AppoientmentDtos
{
    public class CreatDto
    {
        public DateTime AppointmentDate { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
    }
}



namespace Clinic_Management_API.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();


    }
}

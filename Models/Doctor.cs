namespace Clinic_Management_API.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Specialization { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

namespace Clinic_Management_API.Dtos.DoctorDtos
{
    public class UpdateDoctorDto
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string Specialization { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}

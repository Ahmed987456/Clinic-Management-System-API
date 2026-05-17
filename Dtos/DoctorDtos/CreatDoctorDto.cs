namespace Clinic_Management_API.Dtos.DoctorDtos
{
    public class CreatDoctorDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Specialization { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

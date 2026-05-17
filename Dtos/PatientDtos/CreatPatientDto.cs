namespace Clinic_Management_API.Dtos.PatientDtos
{
    public class CreatPatientDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [Range(1, 120)]
        public int Age { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}

namespace Clinic_Management_API.Dtos.PatientDtos
{
    public class UpdatePatientDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Range(1, 120)]
        public int Age { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}

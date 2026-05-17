namespace Clinic_Management_API.Dtos.PatientDtos
{
    public class PatientDetailsDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public int Age { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public int AppoientmentsCount { get; set; }

    }
}

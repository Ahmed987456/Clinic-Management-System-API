namespace Clinic_Management_API.Services.PatientServices
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAll();

        Task<Patient?> GetById(int id);

        Task<Patient> Creat(Patient patient);

        Patient Update (Patient patient);

        Patient Delete (Patient patient);

        Task<IEnumerable<PatientDetailsDto>> GetAllPatients();
    }
}

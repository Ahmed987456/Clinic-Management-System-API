namespace Clinic_Management_API.Services.DoctorServices
{
    public interface IDoctorService 
    {
        Task<IEnumerable<Doctor>> GetAll();

        Task<Doctor?> GetById(int id);

        Task<Doctor> AddNewDoctor(Doctor doctor);

        Doctor UpdateDoctor(Doctor doctor);

        Doctor DelteDoctor(Doctor doctor);
    }
}

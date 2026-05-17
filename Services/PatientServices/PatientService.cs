using Clinic_Management_API.Data;

namespace Clinic_Management_API.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetById(int id)
        {
            return await _context.Patients.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> Creat(Patient patient)
        {
            var existingPhone = await _context.Patients.AnyAsync(s => s.PhoneNumber == patient.PhoneNumber);
               if (existingPhone) return null;
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public Patient Update(Patient patient)
        {
            var existingPhone =  _context.Patients .Any(p =>p.PhoneNumber == patient.PhoneNumber && p.Id != patient.Id);

            if (existingPhone)
                return null;

            _context.Patients.Update(patient);
            _context.SaveChangesAsync();

            return patient;
        }

        public Patient Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return patient;
        }

        public async Task<IEnumerable<PatientDetailsDto>> GetAllPatients()
        {
            return await _context.Patients.Select(p => new PatientDetailsDto
            {
                Id = p.Id,
                PhoneNumber = p.PhoneNumber,
                Age = p.Age,
                AppoientmentsCount = p.Appointments.Count()
            }).ToListAsync();
        }
    }
}

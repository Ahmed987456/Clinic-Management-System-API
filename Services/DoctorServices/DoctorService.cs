using Clinic_Management_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Management_API.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Doctor>> GetAll()
        {
          return await _context.Doctors.ToListAsync();
        }

        public async Task <Doctor> GetById(int id)
        {
            return await _context.Doctors.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor> AddNewDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return doctor;
         }

        public Doctor DelteDoctor(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return doctor;
        }
    }
}


using Clinic_Management_API.Models;
using System.Linq.Expressions;

namespace Clinic_Management_API.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) {}
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Doctor>().HasData(
        //        new Doctor {
        //        Id = 1,
        //        Name= "Ahmed El-Sayed",
        //        Specialization= "Cardiology",
        //        Email= "cardiology.demo1@hospital.com"
        //        },
        //         new Doctor
        //         {
        //             Id = 2,
        //             Name = "Mona Hassan",
        //             Specialization = "Dermatology",
        //             Email = "derma.demo2@clinic.com"
        //         }

        //        );
        //    builder.Entity<Patient>().HasData(
        //        new Patient {
        //         Id = 1,
        //        Name="Ahmed Oraby",
        //        Age=24,
        //        PhoneNumber="01060364652"
        //        },
        //         new Patient
        //         {
        //             Id = 2,
        //             Name = "Osama Oraby",
        //             Age = 27,
        //             PhoneNumber = "01203403045"
        //         }
        //        );
        //    builder.Entity<Appointment>().HasData(
        //        new Appointment
        //        {
        //            Id = 1,
        //            DoctorId = 1,
        //            PatientId = 1,
        //            AppointmentDate = new DateTime(2026, 5, 11, 10, 0, 0, DateTimeKind.Utc),
        //            Status =  Enums.AppointmentStatus.Pending,
        //        },
        //           new Appointment
        //           {
        //               Id = 2,
        //               DoctorId = 2,
        //               PatientId = 2,
        //               AppointmentDate = new DateTime(2026, 5, 12, 11, 0, 0, DateTimeKind.Utc),
        //               Status = Enums.AppointmentStatus.Confirmed
        //           },
        //           new Appointment
        //           {
        //               Id = 3,
        //               DoctorId = 1,
        //               PatientId = 2,
        //               AppointmentDate = new DateTime(2026, 5, 13, 11, 0, 0, DateTimeKind.Utc),
        //               Status = Enums.AppointmentStatus.Cancelled
        //           }
        //        );
        //}
        public DbSet<Doctor> Doctors { get; set; }  

        public DbSet<Patient> Patients  { get; set; }

        public DbSet<Appointment> Appointments { get; set; }    
    }
}

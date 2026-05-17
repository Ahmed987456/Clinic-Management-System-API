using Clinic_Management_API.Data;
using Clinic_Management_API.Services.AppointmentServices;
using Clinic_Management_API.Services.DoctorServices;
using Clinic_Management_API.Services.PatientServices;

namespace Clinic_Management_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllers();
            builder.Services.AddControllers() .AddJsonOptions(options =>
        { 
        options.JsonSerializerOptions.Converters.Add(  new System.Text.Json.Serialization.JsonStringEnumConverter());
       });
            builder.Services.AddTransient<IDoctorService, DoctorService>();
            builder.Services.AddTransient<IPatientService, PatientService>();
            builder.Services.AddTransient<IAppointmentService, AppointmentService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(
                options=>options.UseSqlServer(builder.Configuration.GetConnectionString("ConectionString")) );
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clinic_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, "cardiology.demo1@hospital.com", "Ahmed El-Sayed", "Cardiology" },
                    { 2, "derma.demo2@clinic.com", "Mona Hassan", "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Age", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 24, "Ahmed Oraby", "01060364652" },
                    { 2, 27, "Osama Oraby", "01203403045" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "DoctorId", "PatientId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 11, 10, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0 },
                    { 2, new DateTime(2026, 5, 12, 11, 0, 0, 0, DateTimeKind.Utc), 2, 2, 1 },
                    { 3, new DateTime(2026, 5, 13, 11, 0, 0, 0, DateTimeKind.Utc), 1, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

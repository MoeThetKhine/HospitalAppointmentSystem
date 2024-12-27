using HospitalBookingSystem.Database.Models;
using HospitalBookingSystem.Domain.Features.Appointment;
using HospitalBookingSystem.Domain.Features.Doctor;
using HospitalBookingSystem.Domain.Features.Patient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<AppointmentService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

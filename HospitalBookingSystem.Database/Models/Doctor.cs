using System;
using System.Collections.Generic;

namespace HospitalBookingSystem.Database.Models;

public partial class Doctor
{
    public string DoctorId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Experience { get; set; }

    public string Department { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public bool IsAvailable { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}

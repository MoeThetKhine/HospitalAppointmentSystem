﻿namespace HospitalBookingSystem.Database.Models;

#region TblDoctor

public partial class TblDoctor
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

    public virtual ICollection<TblAppointment> TblAppointments { get; set; } = new List<TblAppointment>();
}

#endregion
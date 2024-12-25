﻿namespace HospitalBookingSystem.Database.Models;

#region TblAppointment

public partial class TblAppointment
{
    public string AppointmentId { get; set; } = null!;

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public string DoctorId { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Reason { get; set; } = null!;

    public string? RoomNumber { get; set; }

    public DateOnly BookingDate { get; set; }

    public string Remarks { get; set; } = null!;

    public virtual TblDoctor Doctor { get; set; } = null!;

    public virtual TblPatient Patient { get; set; } = null!;
}

#endregion
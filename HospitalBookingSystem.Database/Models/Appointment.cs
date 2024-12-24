namespace HospitalBookingSystem.Database.Models;

#region Appointment

public partial class Appointment
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

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}

#endregion
namespace HospitalBookingSystem.Domain.Model.Appointment;

#region AppointmentRequestModel

public class AppointmentRequestModel
{

    public string PatientId { get; set; } = null!;

    public string DoctorId { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public string? Reason { get; set; }

    public string Status { get; set; } = null!;
}

#endregion
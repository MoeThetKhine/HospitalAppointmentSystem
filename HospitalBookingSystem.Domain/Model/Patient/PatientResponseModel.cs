namespace HospitalBookingSystem.Domain.Model.Patient;

#region PatientResponseModel

public class PatientResponseModel
{
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string MedicalHistory { get; set; } = null!;
    public string EmergencyContact { get; set; } = null!;
}

#endregion
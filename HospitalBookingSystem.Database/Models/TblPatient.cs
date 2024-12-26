namespace HospitalBookingSystem.Database.Models;

public partial class TblPatient
{
    public string PatientId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? MedicalHistory { get; set; }

    public string? EmergencyContact { get; set; }

    public string? InsuranceDetails { get; set; }
}

namespace HospitalBookingSystem.Domain.Model.Doctor;

#region DoctorModel

public class DoctorModel
{
    public string DoctorId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsAvailable { get; set; }
}

#endregion

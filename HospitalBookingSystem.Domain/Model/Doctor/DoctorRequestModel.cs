namespace HospitalBookingSystem.Domain.Model.Doctor;

#region DoctorRequestModel

public class DoctorRequestModel
{
    public string Name { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;
}

#endregion
namespace HospitalBookingSystem.Database.Models;

#region TblDoctor

public partial class TblDoctor
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
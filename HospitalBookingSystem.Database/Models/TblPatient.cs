using System.ComponentModel.DataAnnotations;

namespace HospitalBookingSystem.Database.Models;

#region TblPatient

public partial class TblPatient
{
    [Key]
    public Guid PatientId { get; set; } 

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string MedicalHistory { get; set; }

    [Required]
    public string EmergencyContact { get; set; }

    [Required]
    public string InsuranceDetails { get; set; }

    public virtual ICollection<TblAppointment> TblAppointments { get; set; } = new List<TblAppointment>();
}

#endregion
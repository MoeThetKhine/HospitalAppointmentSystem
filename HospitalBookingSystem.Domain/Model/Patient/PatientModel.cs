﻿namespace HospitalBookingSystem.Domain.Model.Patient;

#region PatientModel

public class PatientModel
{
    public string PatientId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string MedicalHistory { get; set; } = null!;

    public string EmergencyContact { get; set; } = null!;

    public string InsuranceDetails { get; set; } = null!;
}

#endregion
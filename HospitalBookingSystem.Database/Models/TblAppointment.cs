﻿using System;
using System.Collections.Generic;

namespace HospitalBookingSystem.Database.Models;

public partial class TblAppointment
{
    public string AppointmentId { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public string DoctorId { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public string? Reason { get; set; }

    public string Status { get; set; } = null!;
}

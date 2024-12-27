using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBookingSystem.Domain.Model.Appointment
{
    public class AppointmentRequestModel
    {
        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public string DoctorId { get; set; } = null!;

        public string PatientId { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string Reason { get; set; } = null!;

        public string? RoomNumber { get; set; }

        public DateOnly BookingDate { get; set; }

        public string Remarks { get; set; } = null!;

    }
}

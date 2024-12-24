using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBookingSystem.Domain.Model.Doctor
{
    public class DoctorModel
    {
        public string DoctorId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Specialization { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Experience { get; set; }

        public string Department { get; set; } = null!;

        public string LicenseNumber { get; set; } = null!;

        public bool IsAvailable { get; set; }

    }
}

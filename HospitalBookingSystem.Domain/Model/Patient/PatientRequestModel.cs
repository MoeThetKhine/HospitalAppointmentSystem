using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBookingSystem.Domain.Model.Patient
{
    public class PatientRequestModel
    {
        public string Name { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string MedicalHistory { get; set; } = null!;

        public string EmergencyContact { get; set; } = null!;

        public string InsuranceDetails { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace DigituraClinicAPI.Models
{
    public partial class PatientList
    {
        public int PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Sex { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

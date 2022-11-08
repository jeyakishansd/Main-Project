using System;
using System.Collections.Generic;

namespace DigituraClinicAPI.Models
{
    public partial class DoctorList
    {
        public int DoctorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Sex { get; set; }
        public string? Specialization { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}

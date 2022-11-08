using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigituraClinicMVC.Models
{
    public partial class DoctorList
    {
        [Display(Name ="Doctor ID")]
        public int DoctorId { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string? LastName { get; set; }
        [Display(Name ="Gender")]
        public string? Sex { get; set; }
        public string? Specialization { get; set; }
        [Display(Name ="Visiting Hours")]
        public string? VisitingHours { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigituraClinicMVC.Models
{
    public partial class PatientList
    {
        [Display(Name ="Patient ID")]
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "First Name")]

        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]

        public string? LastName { get; set; }
        [Display(Name = "Gender")]

        public string? Sex { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime? DateOfBirth { get; set; }
    }
}

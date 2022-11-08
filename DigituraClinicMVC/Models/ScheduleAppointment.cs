using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigituraClinicMVC.Models
{
    public partial class ScheduleAppointment
    {
        [Display(Name ="Appointment Number")]
        public int AppointmentNumber { get; set; }
        [Display(Name ="Patient ID")]
        public int? PatientId { get; set; }

        public string? Specialization { get; set; }
        [Display(Name ="Doctor ID")]
        public int? DoctorId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name ="Appointment Date")]
        [Required]
        public DateTime? AppointmentDate { get; set; }
        [Display(Name ="Appointment Time")]
        public string? AppointmentTime { get; set; }
    }
}

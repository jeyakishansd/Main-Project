using System.ComponentModel.DataAnnotations;

namespace DigituraClinicMVC.Models
{
    public class AppointmentClass
    {
        [Display (Name ="Doctor ID")]
        public int DoctorId { get; set; }
        public string Specialization { get; set; }
        [Display (Name ="Visiting Hours")]
        public string VisitingHours { get; set; }
        [Display (Name ="Doctor Name")] 
        public string DoctorName { get; set; }  
        public string DoctorList { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get;set; }
        public string AppointmentTime { get; set; }

    }
}

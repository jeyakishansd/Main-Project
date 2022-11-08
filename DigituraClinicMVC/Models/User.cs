using System;
using System.Collections.Generic;

namespace DigituraClinicMVC.Models
{
    public partial class User
    {
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
    }
}

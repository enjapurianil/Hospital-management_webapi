using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital_Management_WebApi.Models.Context
{
    public partial class DoctorLogin
    {
        public int LoginId { get; set; }
        public string DoctorId { get; set; }
        public string DoctorPassword { get; set; }
        public int? Id { get; set; }

        public virtual Doctor IdNavigation { get; set; }
    }
}

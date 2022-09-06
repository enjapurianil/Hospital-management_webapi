using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital_Management_WebApi.Models.Context
{
    public partial class Doctor
    {
        public Doctor()
        {
            DoctorLogins = new HashSet<DoctorLogin>();
        }

        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorDesignation { get; set; }

        public virtual ICollection<DoctorLogin> DoctorLogins { get; set; }
    }
}

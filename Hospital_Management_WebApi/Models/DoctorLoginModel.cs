using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Models
{
    public class DoctorLoginModel
    {
        public string DoctorId { get; set; }
        public string DoctorPassword { get; set; }
    }
}

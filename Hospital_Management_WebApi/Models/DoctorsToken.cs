using Hospital_Management_WebApi.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Models
{
    public class DoctorsToken
    {
        private readonly DoctorLogin doctor;

        public DoctorsToken(DoctorLogin _doctor)
        {
            doctor = _doctor;
        }
       // [JsonIgnore]
        public Doctor doct { get; set; }
        public string Token { get; set; }
    }
}

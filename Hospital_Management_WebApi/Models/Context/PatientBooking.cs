using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital_Management_WebApi.Models.Context
{
    public partial class PatientBooking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Locality { get; set; }
        public long? Mobile { get; set; }
        public string ChooseDoctorType { get; set; }
        public string Problem { get; set; }
        public string Status { get; set; }
    }
}

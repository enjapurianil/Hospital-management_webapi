using Hospital_Management_WebApi.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Services.IRepositories
{
    public interface IPatientBookingRepository
    {
        Task<PatientBooking> PostPatientBooking(PatientBooking patientBooking);
        Task<PatientBooking> UpdatePatientBooking(PatientBooking patientBooking);
        Task<int> DeletePatientBooking(int id);
        Task<PatientBooking> GetPatientBooking(int id);
        Task<IEnumerable<PatientBooking>> GetAllPatientBookings();
        Task<IEnumerable<PatientBooking>> GetAllPatientBookingsById(string name);
    }
}

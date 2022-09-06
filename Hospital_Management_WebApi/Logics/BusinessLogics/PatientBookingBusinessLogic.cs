using Hospital_Management_WebApi.Models.Context;
using Hospital_Management_WebApi.Services.IBusinessLogics;
using Hospital_Management_WebApi.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Logics.BusinessLogics
{
    public class PatientBookingBusinessLogic : IPatientBookingBusinessLogic
    {
        private readonly IPatientBookingRepository iPatientBookingRepository;

        public PatientBookingBusinessLogic(IPatientBookingRepository _iPatientBookingRepository)
        {
            iPatientBookingRepository = _iPatientBookingRepository;
        }

        public async Task<int> DeletePatientBooking(int id)
        {
            return await iPatientBookingRepository.DeletePatientBooking(id);
        }

        public async Task<IEnumerable<PatientBooking>> GetAllPatientBookings()
        {
            return await iPatientBookingRepository.GetAllPatientBookings();
        }

        public async Task<PatientBooking> GetPatientBooking(int id)
        {
            return await iPatientBookingRepository.GetPatientBooking(id);
        }

        public async Task<PatientBooking> PostPatientBooking(PatientBooking patientBooking)
        {
            return await iPatientBookingRepository.PostPatientBooking(patientBooking);
        }

        public async Task<PatientBooking> UpdatePatientBooking(PatientBooking patientBooking)
        {
            return await iPatientBookingRepository.UpdatePatientBooking(patientBooking);
        }
        public async Task<IEnumerable<PatientBooking>> GetAllPatientBookingsById(string name)
        {
            return await iPatientBookingRepository.GetAllPatientBookingsById(name);
        }
        
    }
}

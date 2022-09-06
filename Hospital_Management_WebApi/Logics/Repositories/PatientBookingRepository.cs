using Hospital_Management_WebApi.Models.Context;
using Hospital_Management_WebApi.Services.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Logics.Repositories
{
    public class PatientBookingRepository : IPatientBookingRepository
    {
        private readonly HospitalManagementContext context;

        public PatientBookingRepository(HospitalManagementContext _context)
        {
            context = _context;
        }
        public async Task<int> DeletePatientBooking(int id)
        {
           var data = await context.PatientBookings.FindAsync(id);
            context.PatientBookings.Remove(data);
            await context.SaveChangesAsync();
            return 1;
        }

        public async Task<IEnumerable<PatientBooking>> GetAllPatientBookings()
        {
            return await context.PatientBookings.ToListAsync();
        }

        public async Task<PatientBooking> GetPatientBooking(int id)
        {
            return await context.PatientBookings.FindAsync(id);
        }

        public async Task<PatientBooking> PostPatientBooking(PatientBooking patientBooking)
        {
            context.PatientBookings.Add(patientBooking);
            await context.SaveChangesAsync();
            return patientBooking;

        }

        public async Task<PatientBooking> UpdatePatientBooking(PatientBooking patientBooking)
        {
            context.Entry(patientBooking).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return patientBooking;
        }
        public async Task<IEnumerable<PatientBooking>> GetAllPatientBookingsById(string name)
        {
            return await context.PatientBookings.Where(x => x.ChooseDoctorType == name).ToListAsync();
        }


    }
}

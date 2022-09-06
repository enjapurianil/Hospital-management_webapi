using Hospital_Management_WebApi.Models.Context;
using Hospital_Management_WebApi.Services.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Logics.Repositories
{
    public class DoctorRepository : IDoctorsRepository
    {
        private readonly HospitalManagementContext hospitalManagementContext;

        public DoctorRepository(HospitalManagementContext _hospitalManagementContext)
        {
            hospitalManagementContext = _hospitalManagementContext;
        }
        public async Task<int> DeleteDoctor(int id)
        {
           var data = await  hospitalManagementContext.Doctors.FindAsync(id);
            hospitalManagementContext.Doctors.Remove(data);
            await hospitalManagementContext.SaveChangesAsync();
            return 1;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await hospitalManagementContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await hospitalManagementContext.Doctors.FindAsync(id);
        }

        public async Task<Doctor> PostDoctor(Doctor doctor)
        {
            hospitalManagementContext.Doctors.Add(doctor);
            await hospitalManagementContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            hospitalManagementContext.Entry(doctor).State = EntityState.Modified;
            await hospitalManagementContext.SaveChangesAsync();
            return doctor;
        }
    }
}

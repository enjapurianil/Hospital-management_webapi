using Hospital_Management_WebApi.Models.Context;
using Hospital_Management_WebApi.Services.IBusinessLogics;
using Hospital_Management_WebApi.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Logics.BusinessLogics
{
    public class DoctorBusinesslogic : IDoctorsBusinessLogic
    {
        private readonly IDoctorsRepository doctorsRepository;

        public DoctorBusinesslogic(IDoctorsRepository _doctorsRepository)
        {
            doctorsRepository = _doctorsRepository;
        }

        public async Task<int> DeleteDoctor(int id)
        {
            return await doctorsRepository.DeleteDoctor(id);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await doctorsRepository.GetAllDoctors();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await doctorsRepository.GetDoctor(id);
        }

        public async Task<Doctor> PostDoctor(Doctor doctor)
        {
            return await doctorsRepository.PostDoctor(doctor);
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            return await doctorsRepository.UpdateDoctor(doctor);
        }
    }
}

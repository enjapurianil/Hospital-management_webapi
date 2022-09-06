using Hospital_Management_WebApi.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Services.IRepositories
{
    public interface IDoctorsRepository
    {
        Task<Doctor> PostDoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<int> DeleteDoctor(int id);
        Task<Doctor> GetDoctor(int id);
        Task<IEnumerable<Doctor>> GetAllDoctors();
    }
}

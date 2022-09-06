using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_WebApi.Models.Context;

namespace Hospital_Management_WebApi.Services.IBusinessLogics
{
    public interface IDoctorsBusinessLogic
    {
        Task<Doctor> PostDoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<int> DeleteDoctor(int id);
        Task<Doctor> GetDoctor(int id);
        Task<IEnumerable<Doctor>> GetAllDoctors();
    }
}

using Hospital_Management_WebApi.Models.Context;
using Hospital_Management_WebApi.Services.IBusinessLogics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorsBusinessLogic doctorsBusinessLogic;

        public DoctorController(IDoctorsBusinessLogic _doctorsBusinessLogic)
        {
            doctorsBusinessLogic = _doctorsBusinessLogic;
        }
        [HttpDelete,Route("Delete/{id}")]
        public async Task<int> DeleteDoctor(int id)
        {
            return await doctorsBusinessLogic.DeleteDoctor(id);
        }
        [HttpGet,Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
        {
            var DoctorsList = await doctorsBusinessLogic.GetAllDoctors();
            if(DoctorsList == null)
            {
                return NotFound();
            }
            return Ok(DoctorsList);
        }
        [HttpGet,Route("Get/{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var Doctor = await doctorsBusinessLogic.GetDoctor(id);
            if(Doctor == null)
            {
                return NotFound();
            }
            return Doctor; 
        }
        [HttpPost,Route("Post")]
        public async Task<Doctor> PostDoctor(Doctor doctor)
        {
            return await doctorsBusinessLogic.PostDoctor(doctor);
        }
        [HttpPut,Route("Update")]
        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            return await doctorsBusinessLogic.UpdateDoctor(doctor);
        }
    }
}

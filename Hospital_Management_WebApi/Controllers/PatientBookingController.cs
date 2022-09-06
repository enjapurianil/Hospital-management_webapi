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
    public class PatientBookingController : ControllerBase
    {
        private readonly IPatientBookingBusinessLogic iPatientBookingBusinessLogic;

        public PatientBookingController(IPatientBookingBusinessLogic _iPatientBookingBusinessLogic)
        {
            iPatientBookingBusinessLogic = _iPatientBookingBusinessLogic;
        }
        [HttpDelete,Route("Delete/{id}")]
        public async Task<int> DeletePatientBooking(int id)
        {
            return await iPatientBookingBusinessLogic.DeletePatientBooking(id);
        }
        [HttpGet,Route("GetAll")]
        public async Task<ActionResult<IEnumerable<PatientBooking>>> GetAllPatientBookings()
        {
            var patientList = await iPatientBookingBusinessLogic.GetAllPatientBookings();
            if(patientList == null)
            {
                return NotFound();
            }
            return Ok(patientList);
        }
        [HttpGet,Route("Get/{id}")]
        public async Task<ActionResult<PatientBooking>> GetPatientBooking(int id)
        {
            var patient =  await iPatientBookingBusinessLogic.GetPatientBooking(id);
            if(patient == null)
            {
                return NotFound();
            }
            return patient;

        }
        [HttpPost,Route("Post")]
        public async Task<PatientBooking> PostPatientBooking(PatientBooking patientBooking)
        {
            return await iPatientBookingBusinessLogic.PostPatientBooking(patientBooking);
        }
        [HttpPut,Route("Update")]
        public async Task<PatientBooking> UpdatePatientBooking(PatientBooking patientBooking)
        {
            return await iPatientBookingBusinessLogic.UpdatePatientBooking(patientBooking);
        }
        [HttpGet,Route("GetAll/{name}")]
        public async Task<ActionResult<IEnumerable<PatientBooking>>> GetAllPatientBookingsById(string name)
        {
            var patientListByid = await iPatientBookingBusinessLogic.GetAllPatientBookingsById(name);
            if(patientListByid == null)
            {
                return NotFound();
            }
            return Ok(patientListByid);
        }
    }
}

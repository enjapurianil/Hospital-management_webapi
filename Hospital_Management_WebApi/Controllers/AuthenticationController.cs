using Hospital_Management_WebApi.Models;
using Hospital_Management_WebApi.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly HospitalManagementContext hospitalManagementContext;
        private readonly JWTSettings jwtSettings;

        public AuthenticationController(HospitalManagementContext _hospitalManagementContext,
            IOptions<JWTSettings> _jwtSettings)
        {
            hospitalManagementContext = _hospitalManagementContext;
            jwtSettings = _jwtSettings.Value;
        }
        [HttpPost,Route("Login")]
        public async Task<ActionResult<DoctorsToken>> DoctorLogin(DoctorLogin doctorLoginModel)
        {
            var user1 = await hospitalManagementContext.DoctorLogins.Where(x => x.DoctorId == doctorLoginModel.DoctorId && x.DoctorPassword == doctorLoginModel.DoctorPassword).FirstOrDefaultAsync();
            DoctorsToken doctorsToken = new DoctorsToken(user1);
            doctorsToken.doct = await hospitalManagementContext.Doctors.FindAsync(user1.Id);

            if (doctorsToken == null)
            {
                return NotFound();
            }
            //  sign your token here ...

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor();
            tokenDescriptor.Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name , doctorLoginModel.DoctorId)
            });
            tokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(3);
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            doctorsToken.Token = tokenHandler.WriteToken(token);
            return doctorsToken;

        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using physio.Dtos;
using physio.Model;
using physio.Model.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {

        [HttpGet("{docId}")]
        public IActionResult Get(int docId)
        {
            using (var context = new Context())
            {

                var res = from patient in context.DoctorsPatients
                          join user in context.Users on patient.PatientId equals user.Id
                          where patient.DoctorId == docId
                          select new PatientDto()
                          {
                              Id = patient.PatientId,
                              FullName = user.FullName,
                          };

                return Ok(res.ToList().OrderBy(x => x.FullName));
            }
        }

        [HttpPost("NewPatient")]
        public IActionResult AddOpenPosition([FromForm] NewPatientDto newPatientDto)
        {
            using (var context = new Context())
            {
                if (newPatientDto.UserName != null && newPatientDto.FullName != null && newPatientDto.DoctorId != 0)
                {

                    using (var tr = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var result = context.Users.SingleOrDefault(x => x.UserName == newPatientDto.UserName);

                            if (result != null)
                            {
                                return BadRequest("Bu kullanıcı sisteme zaten kayıtlı.");
                            }

                            var user = new User()
                            {
                                UserName = newPatientDto.UserName,
                                FullName = newPatientDto.FullName,
                                IsDoctor = false,
                                Password = newPatientDto.UserName.Substring(0, 6)
                            };
                            context.Users.Add(user);


                            var doctorsPatient = new DoctorsPatient()
                            {
                                DoctorId = newPatientDto.DoctorId,
                                PUser = user,
                            };
                            context.DoctorsPatients.Add(doctorsPatient);


                            context.SaveChanges();
                            tr.Commit();
                        }
                        catch (Exception exc)
                        {
                            var str = exc.Message;
                            tr.Rollback();
                            return BadRequest("Kayıt işemi başarısız.");
                        }
                    }
                }
                else { return BadRequest("Lütfen zorunlu alanları doldurun"); }
            }
            return Ok();
        }


    }
}

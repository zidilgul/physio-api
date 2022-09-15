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
    public class PatientsMoveController : ControllerBase
    {

        [HttpGet("{patientId}")]
        public IActionResult Get(int patientId)
        {
            using (var context = new Context())
            {
                var res = from patientsMove in context.PatientMoves
                          join move in context.Moves on patientsMove.MoveId equals move.Id
                          join bodyPart in context.BodyParts on move.BodyPartId equals bodyPart.Id
                          where patientsMove.PatientId == patientId
                          select new PatientsMovesDto()
                          {
                              Id = patientsMove.Id,
                              MoveId = move.Id,
                              BodyPart = bodyPart.Name,
                              Move = move.Name,
                              NumberOfRepetitons = patientsMove.NumberOfRepetitons,
                              NumberOfSets = patientsMove.NumberOfSets,
                              State = patientsMove.State
                          };

                return Ok(res.ToList());
            }
        }

        [HttpPost("NewPatientMove")]
        public IActionResult Post([FromBody] NewPatientsMove newPatientsMove)
        {
            bool basariDurumu;
            using (var context = new Context())
            {
                // newPatientsMove.NumberOfRepetitons = 12;
                if (newPatientsMove.PatientId!=0 && 
                    newPatientsMove.MoveId !=0 && 
                    newPatientsMove.NumberOfRepetitons!=0 && 
                    newPatientsMove.NumberOfSets !=0)
                {
                        try
                        {
                            var patientsMove = new PatientsMove()
                            {
                                PatientId = newPatientsMove.PatientId,
                                NumberOfRepetitons = newPatientsMove.NumberOfRepetitons,
                                NumberOfSets = newPatientsMove.NumberOfSets,
                                MoveId = newPatientsMove.MoveId,
                                State = false,
                            };
                            context.PatientMoves.Add(patientsMove);
                            context.SaveChanges();
                        basariDurumu = true;

                    }
                    catch (Exception exc)
                        {
                        basariDurumu = false;
                            var str = exc.Message;
                            return BadRequest(basariDurumu);
                        }
                    }
                else { return BadRequest("Lütfen zorunlu alanları doldurun"); }
            }

            return Ok(basariDurumu);
        }


    }
}

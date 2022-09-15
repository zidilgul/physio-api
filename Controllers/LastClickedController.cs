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
    public class LastClickedController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new Context())
            {
                var result = context.LastClickeds.ToList().OrderBy(x => x.Id);
                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewClick newClick)
        {
            bool basariDurumu;
            using (var context = new Context())
            {
                if (newClick.PatientsMoveId != null)
                {
                    try
                    {
                        var click = new LastClicked()
                        {
                            PatientsMoveId = newClick.PatientsMoveId
                        };
                        context.LastClickeds.Add(click);
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
                else { return BadRequest("Hata"); }
            }

            return Ok(basariDurumu);
        }
    }
}

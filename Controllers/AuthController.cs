using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using physio.Dtos;
using physio.Model.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            bool basariDurumu = false;
            using (var context = new Context())
            {
                try
                {
                    var result = context.Users.SingleOrDefault(x => x.UserName == loginDto.UserName && x.Password == loginDto.Password);

                    if (result == null)
                    {
                        basariDurumu = false;
                        return BadRequest(basariDurumu);
                    }
                    basariDurumu = true;

                    return Ok(result);
                }
                catch (Exception exc)
                {
                    return BadRequest("Giriş başarısız.");
                }
            }
        }

    }
}

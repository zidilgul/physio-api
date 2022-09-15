using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using physio.Model.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = new Context())
            {
                var result = context.Users.Where(x => x.Id == id ).SingleOrDefault();
                return Ok(result);
            }
        }
    }
}

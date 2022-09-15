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
    public class BodyPartController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new Context())
            {
                var result = context.BodyParts.ToList().OrderBy(x=> x.Name);
                return Ok(result);
            }
        }
    }
}

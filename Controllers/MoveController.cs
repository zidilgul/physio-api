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
    public class MoveController : ControllerBase
    {
        [HttpGet("{bodyPartId}")]
        public IActionResult Get(int bodyPartId)
        {
            using (var context = new Context())
            {
                var result = context.Moves.Where(x=> x.BodyPartId == bodyPartId).ToList().OrderBy(x => x.Name);
                return Ok(result);
            }
        }
    }
}

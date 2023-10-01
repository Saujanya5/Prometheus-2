using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prometheus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public  class SessionController : ControllerBase
    {
        public static Dictionary<string, string> sessionCodes;
        public SessionController()
        {
            sessionCodes = new Dictionary<string, string>();
        }
        [HttpGet]
        [Route("Logout")]
        public async  Task<IActionResult> Logout(string code)
        {
            sessionCodes.Remove(code);
            return NoContent();
        }
    }
}

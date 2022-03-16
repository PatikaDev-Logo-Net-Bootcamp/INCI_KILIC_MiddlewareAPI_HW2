using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INCI_KILIC_MiddlewareAPI_HW2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("/home")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("/register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpGet("/deleted")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}

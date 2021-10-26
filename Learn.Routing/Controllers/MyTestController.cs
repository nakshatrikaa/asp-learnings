using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Routing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyTestController : ControllerBase
    {
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return $"Hello from Controller {name}";
        }

    }
}

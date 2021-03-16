using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace reisefradragApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReisefradragController : ControllerBase
    {
        [HttpGet]
        public string ReisefradragRequest()
        {
            return "Hello world!";
        }
    }
}
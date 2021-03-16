using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace reisefradragApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReiseFradragController : ControllerBase
    {
        [HttpGet]
        public string GetReisefradrag()
        {
            return "Hello world!";
        }
    }
}
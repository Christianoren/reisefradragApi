using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reisefradragApi.Services;
using reisefradragApi.Models;

namespace reisefradragApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReisefradragController : ControllerBase
    {
        private readonly ReisefradragService _reisefradragService;
        public ReisefradragController(ReisefradragService reisefradragService)
        {
            _reisefradragService = reisefradragService;
        }

        [HttpGet]
        // public ReisefradragResult ReisefradragRequest([FromBody] ReisefradragRequest rfr)
        public ReisefradragResult ReisefradragRequest()
        {
            //TODO: Logging?
            //TODO: validate request
            //TODO: calculate deduction
            //TODO: return result
            return _reisefradragService.Reisefradrag();
        }
    }
}
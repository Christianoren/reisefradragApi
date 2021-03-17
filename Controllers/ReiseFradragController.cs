using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reisefradragApi.Services;
using reisefradragApi.Models;
using reisefradragApi.Validation;
using FluentValidation;
using FluentValidation.Results;

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

        [HttpPost]
        public async Task<IActionResult> ReisefradragRequest([FromBody] ReisefradragRequest rfr)
        {
            ReisefradragValidator validator = new ReisefradragValidator();
            ValidationResult validationResult = validator.Validate(rfr);

            if (!validationResult.IsValid)
            {
                var allErrorMessages = validationResult.ToString(" ~ ");
                return BadRequest(allErrorMessages);
            }

            var reisefradragResult = _reisefradragService.Reisefradrag(rfr);

            return Ok(reisefradragResult);
        }
    }
}
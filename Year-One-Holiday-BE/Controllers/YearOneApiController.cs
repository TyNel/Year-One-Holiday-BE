
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Year_One.Services.Interfaces;
using YearOne.Models.Requests;

namespace Year_One_Holiday_BE.Controllers
{
    [ApiController]
    [Route("api/cookies/")]
    public class YearOneApiController : ControllerBase
    {
        ICookieService _service = null;
        public YearOneApiController(ICookieService service)
        {
            _service = service;
        }

        [HttpGet("CookieType")]

        public async Task<IActionResult> GetCookieTypes()
        {
            return Ok(await _service.GetCookieTypes());
        }

        [HttpPost]

        public async Task<IActionResult> AddUser([FromBody] UserAddRequest user)
        {
            return Ok(await _service.AddUser(user));
        }
    } 
}

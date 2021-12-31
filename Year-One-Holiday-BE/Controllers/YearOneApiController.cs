
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

        [HttpGet("cookieType")]

        public async Task<IActionResult> GetCookieTypes()
        {
            return Ok(await _service.GetCookieTypes());
        }

        [HttpPost("addUser")]

        public async Task<IActionResult> AddUser([FromBody] UserAddRequest user)
        {
            return Ok(await _service.AddUser(user));
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] UserLogin loginRequest)
        {
            return Ok(await _service.Login(loginRequest));
        }

        [HttpPost("addCookie")]

        public async Task<IActionResult> AddCookie([FromBody] CookieAddRequest cookieRequest)
        {
            return Ok(await _service.AddCookie(cookieRequest));
        }

        [HttpPost("addRecipe")]

        public async Task<IActionResult> AddRecipe([FromBody] RecipeAddRequest recipeRequest)
        {
            return Ok(await _service.AddRecipe(recipeRequest));
        }

        [HttpGet("recipe")]

        public async Task<IActionResult> GetRecipe(int id)
        {
            return Ok(await _service.GetRecipe(id));
        }
    } 
}


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
using YearOne.Models.Entities;
using Year_One.Services.CommonMethods;

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
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                if (user.Password != user.ConfirmPassword)

                {
                    return BadRequest(new ErrorResponse("Password does not match confirm password."));
                }

                User existingEmail = await _service.GetByEmail(user.Email);

                if (existingEmail != null)
                {
                    return Conflict(new ErrorResponse("Email already exists"));
                }
                else
                {
                    return Ok(await _service.AddUser(user));

                }
            }


            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");
               
                return StatusCode(500, response);
            }
        }
        
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] UserLogin loginRequest)
        {
           
                if (!ModelState.IsValid)
                {

                    return BadRequestModelState();

                }

            User user = await _service.GetByEmail(loginRequest.Email);

            if (user == null)
            {
                return Unauthorized();

            }

            var LoginUser = await _service.Login(loginRequest);

            if (LoginUser == null)
            {
                return BadRequestModelState();
            }

            if (PwManager.Decrypt(LoginUser.Password) != loginRequest.Password)
            {
                return Unauthorized();
            }

            return Ok(await _service.Login(loginRequest));

        }

        [HttpPost("addCookie")]

        public async Task<IActionResult> AddCookie([FromBody] CookieAddRequest cookieRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }
                else
                {
                    return Ok(await _service.AddCookie(cookieRequest));
                }
            }
            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");


                return StatusCode(500, response);
            }

        }

        [HttpPost("addRecipe")]

        public async Task<IActionResult> AddRecipe([FromBody] RecipeAddRequest recipeRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }
                else
                {
                    return Ok(await _service.AddRecipe(recipeRequest));
                }

            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");
               
                return StatusCode(500, response);
            }

            
        }

        [HttpGet("recipe")]

        public async Task<IActionResult> GetRecipe(int id)
        {
            return Ok(await _service.GetRecipe(id));
        }
        [HttpPost("liked")]

        public async Task<IActionResult> LikedRecipe([FromBody] UserLikedRecipe recipeLikeRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }
                else
                {
                    return Ok(await _service.LikedRecipe(recipeLikeRequest));
                }

            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }

          
        }

        [HttpGet("recipe/liked")]

        public async Task<IActionResult> GetLikes(int id)
        {
            return Ok(await _service.GetLikes(id));
        }

        [HttpPut("disliked")]

        public async Task<IActionResult> DislikedRecipe(UserLikedRecipe recipeDislike)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }
                else
                {
                    return Ok(await _service.DislikedRecipe(recipeDislike));
                }

            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpPut("passwordUpdate")]

        public async Task<IActionResult> UpdatePassword(PasswordUpdateRequest userRequest)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }
                else
                {
                    return Ok(await _service.UpdatePassword(userRequest));
                }

            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }





        private IActionResult BadRequestModelState()
        {
            IEnumerable<string> errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));

            return BadRequest(new ErrorResponse(errorMessages));
        }

    } 
}

using EpedimiologicReport.Services.Dtos;
using EpedimiologicReport.Dal.Models;
using EpedimiologicReport.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EpedimiologicReport.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginDto user)
        {
            
            var token = await _userService.LoginWithDto(user);

            if (token==null)
            {
                return  Unauthorized();

            }
            return Ok(token);
        }
        //userLoginDto
        [HttpPost("signUp")]
        public async Task<ActionResult<string>> SignUp([FromBody] UserLoginDto user)
            {
            if (user==null || user.Name == null || user.Password == null)
            {
                return BadRequest();
            }
            var token = await _userService.SignUp(user);

            if (token == null)
            {
                return BadRequest();
            }
            return Ok(token);
        }
        [Authorize]
        [HttpGet]
        public ActionResult<string> GetUserName()
        {
            try
            {
                var userName = User.Claims.FirstOrDefault(
                            x => x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value; ;
                return Ok(userName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /*
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        string name = "";
        if (identity != null)
        {
            IEnumerable<Claim> claims = identity.Claims;
            // or
           name= identity.FindFirst("UserName").Value;
        }*//*

       var  name = User.Claims.FirstOrDefault(
                    x => x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value;
        if (name==null)
        {
            return NotFound(); 
        }
        return Ok(name);*/

    }
}

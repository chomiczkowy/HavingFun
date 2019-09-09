using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HavingFun.Common.Consts;
using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace HavingFun.API.Main.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private ITokenProvider _tokenProvider;
        private CustomSettings _appSettings;

        public UsersController(IUserService userService, ITokenProvider tokenProvider, CustomSettings appSettings)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
            _appSettings = appSettings;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            user.Token = _tokenProvider.CreateToken(user, _appSettings.JWTSecret);

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll(int pageSize, int pageNumber)
        {          
            var requiredClaim = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == CustomClaims.CanSeeUsersList);
            if (requiredClaim == null || requiredClaim.Value != ClaimsDefaultValues.Allow)
            {
                return Forbid();
            }

            var users = _userService.GetAll(pageSize, pageNumber);
            return Ok(users);
        }
    }
}
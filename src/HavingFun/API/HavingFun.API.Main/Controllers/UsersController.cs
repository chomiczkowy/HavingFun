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
        public IActionResult GetAll()
        {
            StringValues authHeaders = this.Request.Headers["Authorization"];
            if (authHeaders.Count() > 1)
            {
                return Unauthorized();
            }

            string authHeaderVal = authHeaders.First();
            string userToken = authHeaderVal.Replace("Bearer ", string.Empty);

            var claims = _tokenProvider.GetClaims(userToken);

            var requiredClaim = claims.FirstOrDefault(x => x.Type == CustomClaims.CanSeeUsersList);
            if (requiredClaim == null || requiredClaim.Value != ClaimsDefaultValues.Allow)
            {
                return Unauthorized();
            }

            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
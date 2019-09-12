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
    [Route("api/login")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        private ITokenProvider _tokenProvider;
        private CustomSettings _appSettings;

        public LoginController(IUserService userService, ITokenProvider tokenProvider, CustomSettings appSettings)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
            _appSettings = appSettings;
        }


        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Authenticate([FromBody]UserLoginModel userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            user.Token = _tokenProvider.CreateToken(user, _appSettings.JWTSecret);

            return Ok(user);
        }
    }
}
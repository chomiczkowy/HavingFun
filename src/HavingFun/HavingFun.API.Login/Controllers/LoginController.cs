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
using HavingFun.API.Common;
using HavingFun.Common;

namespace HavingFun.API.Login.Controllers
{
    [Route("api/login")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        private ITokenProvider _tokenProvider;
        private LoginApiSettings _appSettings;
        private LoggerHelper _logger;

        public LoginController(IUserService userService, ITokenProvider tokenProvider, LoginApiSettings appSettings,
            LoggerHelper logger)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
            _appSettings = appSettings;
            _logger = logger;
        }


        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Authenticate([FromBody]UserLoginModel userParam)
        {
            var cmd = Request.ToCommand(userParam, true);
            var user = _userService.Authenticate(cmd);


            if (user == null)
            {
                _logger.Warn("Invalid login attempt for user: " + userParam.Username);
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            user.Token = _tokenProvider.CreateToken(user, _appSettings.JWTSecret);
            _logger.Info("Logged in user: " + userParam.Username);

            return Ok(user);
        }
    }
}
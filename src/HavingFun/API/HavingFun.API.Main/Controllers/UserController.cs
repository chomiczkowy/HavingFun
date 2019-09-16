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
using HavingFun.Common;
using HavingFun.API.Common;
using HavingFun.Common.Exceptions;

namespace HavingFun.API.Main.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private LoggerHelper _logger;

        public UserController(IUserService userService, LoggerHelper logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [AllowAnonymous]
        [HttpPut]
        public IActionResult Register([FromBody]EditUserModel userModel)
        {
            _logger.Trace("New user registration attempt: " + userModel.Username);

            var id = _userService.Create(Request.ToCommand(userModel, true));
            _logger.Info("New user registered: " + userModel.Username);

            return Ok(id);
        }

        [HttpPost]
        public IActionResult Update([FromBody]EditUserModel userModel)
        {
            _logger.Trace("User update attempt: " + userModel.Username);
            Command<EditUserModel> cmd = null;
            try
            {
                cmd = Request.ToCommand(userModel);
            }
            catch(HavingFunSecurityException exc)
            {
                _logger.Warn(exc);
                return BadRequest(exc.Message);
            }

            if (userModel.Id!= cmd.ExecutingUserId)
            {
                return BadRequest("User cannot edit other user's data.");
            }

            var id = _userService.Update(cmd);

            _logger.Info("User update completed: " + userModel.Username);
            return Ok(id);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var query = Request.ToQuery(id);
            var user = _userService.GetById(query);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
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
    public class UsersListController : ControllerBase
    {
        private IUserService _userService;

        public UsersListController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll(int pageSize, int pageNumber)
        {
            var requiredClaim = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == CustomClaims.CanSeeUsersList);
            if (requiredClaim == null || requiredClaim.Value != ClaimsDefaultValues.Allow)
            {
                return Forbid();
            }

            var users = _userService.GetPage(pageSize, pageNumber);
            return Ok(users);
        }
    }
}
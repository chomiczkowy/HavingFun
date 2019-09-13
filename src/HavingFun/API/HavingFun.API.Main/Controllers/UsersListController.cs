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
            if (!Request.UserHasRequiredPermissions(CustomClaims.CanSeeUsersList))
                return Forbid();

            var query = Request.ToQuery(new PageableQueryParameters() { PageNumber = pageNumber, PageSize = pageSize });

            var users = _userService.GetPage(query);
            return Ok(users);
        }
    }
}
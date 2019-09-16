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

namespace HavingFun.API.Admin.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersListController : ControllerBase
    {
        private IUserService _userService;
        private LoggerHelper _logger;

        public UsersListController(IUserService userService, LoggerHelper logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int pageSize, int pageNumber)
        {
            if (!Request.UserHasRequiredPermissions(CustomClaims.CanSeeUsersList))
            {
                _logger.Warn("Attempt to get users list failed. " + (User?.Identity != null ? "Logged user: " + User.GetUsername() + " does not have sufficient permissions" : "Not logged in."));
                return Forbid();
            }

            var query = Request.ToQuery(new PageableQueryParameters() { PageNumber = pageNumber, PageSize = pageSize });

            var users = _userService.GetPage(query);
            _logger.Info($"Users list page {pageNumber} with page size {pageSize} served for user { User.GetUsername()}");
            return Ok(users);
        }
    }
}
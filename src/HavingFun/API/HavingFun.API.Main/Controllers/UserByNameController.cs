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
    [Route("api/userByName")]
    [ApiController]
    public class UserByNameController : ControllerBase
    {
        private IUserService _userService;

        public UserByNameController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get(string name)
        {
            var query = Request.ToQuery(name, true);

            var user = _userService.GetByName(query);
            return Ok(user?.Id);
        }
    }
}

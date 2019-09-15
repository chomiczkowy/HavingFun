using HavingFun.Common.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using HavingFun.API.Common;

namespace HavingFun.API.Main.Controllers
{
    [ApiVersion("1.0")]
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

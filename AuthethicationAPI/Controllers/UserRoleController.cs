using Authentication.Core.Models;
using Authentication.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleServiceAsync service;
        public UserRoleController(IUserRoleServiceAsync service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserRoleRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddUserRoleAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetUserRoleByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllUserRoles());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteUserRoleAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UserRoleRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateUserRoleAsync(model));
            }
            return BadRequest();
        }
    }
}


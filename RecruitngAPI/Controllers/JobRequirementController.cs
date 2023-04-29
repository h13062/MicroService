using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.Core.Models;
using Recruiting.Core.Service;

namespace RecruitngAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequirementController : ControllerBase
    {
        private readonly IJobRequirementServiceAsync service;
        public JobRequirementController(IJobRequirementServiceAsync service)
        {
            this.service = service;

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(JobRequirementRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddJobRequirementAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetJobRequirementByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllJobRequirements());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteJobRequirementAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(JobRequirementRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateJobRequirementAsync(model));
            }
            return BadRequest();
        }
    }
}

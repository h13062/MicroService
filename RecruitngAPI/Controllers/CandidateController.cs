using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.Core.Models;
using Recruiting.Core.Service;

namespace RecruitngAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateServiceAsync candidatesService;
        public CandidateController(ICandidateServiceAsync candidatesService)
        {
            this.candidatesService = candidatesService;
        }

        [HttpGet("Get")]
        //[Route("GetAllCandidates")]
        public async Task<IActionResult> Get()
        {
            return Ok(await candidatesService.GetAllCandidates());
        }

        [HttpGet("GetById")]
        //[Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await candidatesService.GetCandidateByIdAsync(id);
            if (candidates == null)
            {
                return NotFound($"Candidate object with Id = {id} is not available");
            }
            return Ok(candidates);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post(CandidateRequestModel model)
        {
            var result = await candidatesService.AddCandidateAsync(model);
            if (result != 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await candidatesService.DeleteCandidateAsync(id);
            if (result != 0)
            {
                return Ok("Candidate Deleted Successfully");
            }
            return BadRequest();
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(CandidateRequestModel model)
        {
            if (model != null)
            {
                return Ok(await candidatesService.UpdateCandidateAsync(model));
            }
            return BadRequest();
        }
    }
}

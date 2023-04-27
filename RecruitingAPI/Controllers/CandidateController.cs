using Microsoft.AspNetCore.Mvc;
using RecruitingCore.Models;
using RecruitingCore.Service;

namespace RecruitingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService candidatesService;
        public CandidateController(ICandidateService candidatesService)
        {
            this.candidatesService = candidatesService;
        }

        [HttpGet]
        [Route("GetAllCandidates")]
        public async Task<IActionResult> Get()
        {
            return Ok(await candidatesService.GetAllCandidates());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await candidatesService.GetCandidateByIdAsync(id);
            if (candidates == null)
            {
                return NotFound($"Candidate object with Id = {id} is not available");
            }
            return Ok(candidates);
        }

        [HttpPost]
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
    }
}

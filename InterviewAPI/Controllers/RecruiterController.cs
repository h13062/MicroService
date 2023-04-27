using InterviewCore.Model;
using InterviewCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterServiceAsync recruiterServiceAsync;
        public RecruiterController(IRecruiterServiceAsync _recruiterServiceAsync)
        {
            this.recruiterServiceAsync = _recruiterServiceAsync;
        }

        [HttpGet]
        [Route("GetAllRecruiters")]
        public async Task<IActionResult> Get()
        {
            return Ok(await recruiterServiceAsync.GetAllRecruiters());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await recruiterServiceAsync.GetRecruiterByIdAsync(id);
            if (candidates == null)
            {
                return NotFound($"Recruiter with Id = {id} is not available");
            }
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RecruiterRequestModel model)
        {
            var result = await recruiterServiceAsync.AddRecruiterAsync(model);
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
            var result = await recruiterServiceAsync.DeleteRecruiterAsync(id);
            if (result != 0)
            {
                return Ok("Recruiter FeedBack with id: " + id + " Deleted Successfully");
            }
            return BadRequest();
        }

    }
}

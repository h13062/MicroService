using InterviewCore.Model;
using InterviewCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;
        public InterviewController(IInterviewServiceAsync _interviewServiceAsync)
        {
            this.interviewServiceAsync = _interviewServiceAsync;
        }

        [HttpGet]
        [Route("GetAllInterviewFeedBacks")]
        public async Task<IActionResult> Get()
        {
            return Ok(await interviewServiceAsync.GetAllInterviews());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await interviewServiceAsync.GetInterviewByIdAsync(id);
            if (candidates == null)
            {
                return NotFound($"Interview with Id = {id} is not available");
            }
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewRequestModel model)
        {
            var result = await interviewServiceAsync.AddInterviewAsync(model);
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
            var result = await interviewServiceAsync.DeleteInterviewAsync(id);
            if (result != 0)
            {
                return Ok("Innterview with id: " + id + " Deleted Successfully");
            }
            return BadRequest();
        }

    }
}

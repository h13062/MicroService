using InterviewCore.Model;
using InterviewCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerServiceAsync interviewerServiceAsync;
        public InterviewerController(IInterviewerServiceAsync interviewerServiceAsync)
        {
            this.interviewerServiceAsync = interviewerServiceAsync;
        }

        [HttpGet]
        [Route("GetAllInterviewers")]
        public async Task<IActionResult> Get()
        {
            return Ok(await interviewerServiceAsync.GetAllInterviewers());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await interviewerServiceAsync.GetInterviewerByIdAsync(id);
            if (candidates == null)
            {
                return NotFound($"Interviewer with Id = {id} is not available");
            }
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewerRequestModel model)
        {
            var result = await interviewerServiceAsync.AddInterviewerAsync(model);
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
            var result = await interviewerServiceAsync.DeleteInterviewerAsync(id);
            if (result != 0)
            {
                return Ok("Innterviewer with id: " + id + " Deleted Successfully");
            }
            return BadRequest();
        }
    }
}

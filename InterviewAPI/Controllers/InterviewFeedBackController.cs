using InterviewCore.Model;
using InterviewCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewFeedBackController : ControllerBase
    {
        private readonly IInterviewFeedBackServiceAsync innterviewFeedBackServiceAsync;
        public InterviewFeedBackController(IInterviewFeedBackServiceAsync _innterviewFeedBackServiceAsync)
        {
            this.innterviewFeedBackServiceAsync = _innterviewFeedBackServiceAsync;
        }

        [HttpGet]
        [Route("GetAllInterviewFeedBacks")]
        public async Task<IActionResult> Get()
        {
            return Ok(await innterviewFeedBackServiceAsync.GetAllInterviewFeedBacks());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await innterviewFeedBackServiceAsync.GetInterviewFeedBackByIdAsync(id);
            if (candidates == null)
            {
                return NotFound($"Interview feedback with Id = {id} is not available");
            }
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewFeedBackRequestModel model)
        {
            var result = await innterviewFeedBackServiceAsync.AddInterviewFeedBackAsync(model);
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
            var result = await innterviewFeedBackServiceAsync.DeleteInterviewFeedBackAsync(id);
            if (result != 0)
            {
                return Ok("Innterview FeedBack with id: "+ id +" Deleted Successfully");
            }
            return BadRequest();
        }
    }
}

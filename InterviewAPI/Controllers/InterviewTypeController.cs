using InterviewCore.Model;
using InterviewCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewTypeController : ControllerBase
    {
        private readonly IInterviewTypeServiceAsync interviewTypeServiceAsync;
        public InterviewTypeController(IInterviewTypeServiceAsync _interviewTypeServiceAsync)
        {
            this.interviewTypeServiceAsync = _interviewTypeServiceAsync;
        }

        [HttpGet]
        [Route("GetAllInterviewTypes")]
        public async Task<IActionResult> Get()
        {
            return Ok(await interviewTypeServiceAsync.GetAllInterviewTypes());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await interviewTypeServiceAsync.GetInterviewTypeByIdAsync(id);
            if (candidates == null)
            {
                return NotFound($"Interview type with Id = {id} is not available");
            }
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewTypeRequestModel model)
        {
            var result = await interviewTypeServiceAsync.AddInterviewTypeAsync(model);
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
            var result = await interviewTypeServiceAsync.DeleteInterviewTypeAsync(id);
            if (result != 0)
            {
                return Ok("Innterview Type with id: " + id + " Deleted Successfully");
            }
            return BadRequest();
        }

    }
}

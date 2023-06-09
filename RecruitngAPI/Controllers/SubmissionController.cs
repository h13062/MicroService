﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.Core.Models;
using Recruiting.Core.Service;

namespace RecruitngAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionServiceAsync service;
        public SubmissionController(ISubmissionServiceAsync service)
        {
            this.service = service;

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddSubmissionAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetSubmissionByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllSubmissions());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteSubmissionAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(SubmissionRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateSubmissionAsync(model));
            }
            return BadRequest();
        }
    }
}

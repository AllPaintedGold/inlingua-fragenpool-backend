using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Services.SubjectService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
         private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("AddSubject")]
        public async Task<ActionResult<ServiceResponse<Subject>>> AddSubject(Subject newSubject)
        {
            return Ok(await _subjectService.AddSubject(newSubject));
        }

        [HttpDelete("DeleteSubject/{id}")]
        public async Task<ActionResult<ServiceResponse<Subject>>> DeleteSubject(int id)
        {
            return Ok(await _subjectService.DeleteSubject(id));
        }
         [HttpGet("GetAllSubjects")]
        public async Task<ActionResult<ServiceResponse<List<Subject>>>> GetAllSubjects()
        {
            return Ok(await _subjectService.GetAllSubjects());
        }
    }
}
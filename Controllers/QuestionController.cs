using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Services.QuestionService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("AddQuestion")]
        public async Task<ActionResult<ServiceResponse<Question>>> AddQuestion(Question newQuestion)
        {
            return Ok(await _questionService.AddQuestion(newQuestion));
        }

        [HttpDelete("DeleteQuestion/{id}")]
        public async Task<ActionResult<ServiceResponse<Question>>> DeleteQuestion(int id)
        {
            return Ok(await _questionService.DeleteQuestion(id));
        }

        [HttpGet("GetQuestionById/{id}")]
        public async Task<ActionResult<ServiceResponse<Question>>> GetQuestionById(int id)
        {
            return Ok(await _questionService.GetQuestionById(id));
        }

        [HttpGet("GetQuestionsForSubject/{subject}")]
        public async Task<ActionResult<ServiceResponse<List<Question>>>> GetQuestionsForSubject(string subject)
        {
            return Ok(await _questionService.GetQuestionsForSubject(subject));
        }

        [HttpPut("UpdateQuestion/{updatedQuestion}")]
        public async Task<ActionResult<ServiceResponse<Question>>> UpdateQuestion(Question updatedQuestion)
        {
            return Ok(await _questionService.UpdateQuestion(updatedQuestion));
        }

    }
}
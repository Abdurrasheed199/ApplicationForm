using ApplicationForm.DTOs;
using ApplicationForm.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionTypeService _questionTypeService;

        public QuestionController(IQuestionService questionService, IQuestionTypeService questionTypeService)
        {
            _questionService = questionService;
            _questionTypeService = questionTypeService;
        }

        [HttpPost("CandidateForm")]
        public async Task<IActionResult> QuestionStored([FromForm]QuestionRequestModel request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var question = await _questionService.StoreQuestion(request, cancellationToken);
            if (question.Status == false) return BadRequest(question);
            return Ok(question);
        }

        [HttpPut("UpdateQuestion")]
        public async Task<IActionResult> EditAdminCart([FromForm]UpdateQuestionRequestModel request, CancellationToken cancellationToken)
        {
            var updateQuestion = await _questionService.EditQuestion(request, cancellationToken);
            if (updateQuestion.Status == false) return BadRequest(updateQuestion);
            return Ok(updateQuestion);
        }

        [HttpGet("GetQuestion/{questionTypeId}")]
        public async Task<IActionResult> GetQuestion([FromRoute]string questionTypeId, CancellationToken cancellationToken)
        {
            var question = await _questionService.GetQuestionByQuestionTypeId(questionTypeId, cancellationToken);
            if (question.Status == false) return BadRequest(question);
            return Ok(question);
        }
    }
}

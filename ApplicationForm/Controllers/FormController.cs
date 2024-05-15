using ApplicationForm.DTOs;
using ApplicationForm.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            
            _formService = formService;
        }

        [HttpPost("SaveForm")]
        public async Task<IActionResult> CandidateForm([FromBody] FormRequestModel request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var form = await _formService.SaveForm(request, cancellationToken);
            if (form.Status == false) return BadRequest(form.Message);
            return Ok(form);
        }
    }
}

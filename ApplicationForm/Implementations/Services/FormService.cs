using ApplicationForm.DTOs;
using ApplicationForm.Interfaces.Repositories;
using ApplicationForm.Interfaces.Services;
using ApplicationForm.Models;

namespace ApplicationForm.Implementations.Services
{
    public class FormService : IFormService
    {
        public readonly IQuestionRepository _questionRepository;
        public readonly IQuestionTypeRepository _questionTypeRepository;
        public readonly IFormRepository _formRepository;

        public FormService(IQuestionRepository questionRepository, IQuestionTypeRepository questionTypeRepository, IFormRepository formRepository)
        {
            _questionRepository = questionRepository;
            _questionTypeRepository = questionTypeRepository;
            _formRepository = formRepository;
        }

        public async Task<BaseResponse<FormDTO>> SaveForm(FormRequestModel request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var getForm = await _formRepository.GetFormByEmail(request.Email, cancellationToken);
            if (getForm == null) 
            {
                return new BaseResponse<FormDTO>
                {
                    Message = " Form Does not Exist",
                    Status = false,
                };
            }
            var formRequestModel = new FormRequestModel
            {

                Email = request.Email,
                Nationality = request.Nationality,
                CurrentAddress = request.CurrentAddress,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdNumber = request.IdNumber,
                PhoneNumber = request.PhoneNumber,
                ProgramTittle = request.ProgramTittle,
                ProgramDescription = request.ProgramDescription,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
            };
            foreach(var form in request.Answers)
            {
                var question = await _questionRepository.GetQuestionById(form.QuestionId,cancellationToken);
                question.Answer = form.Answer;
                await _questionRepository.UpdateQuestion(question, cancellationToken);

            }
            
            await _formRepository.SaveFormAsync(formRequestModel, cancellationToken);
            return new BaseResponse<FormDTO>
            {
                Message = " Succesful",
                Status = true
            };   

            
        }
    }
}

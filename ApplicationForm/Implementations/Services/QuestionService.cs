using ApplicationForm.DTOs;
using ApplicationForm.Interfaces.Repositories;
using ApplicationForm.Interfaces.Services;
using ApplicationForm.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApplicationForm.Implementations.Services
{
    public class QuestionService : IQuestionService
    {

        public readonly IQuestionRepository _questionRepository;
        public readonly IQuestionTypeRepository _questionTypeRepository;

        public QuestionService(IQuestionRepository questionRepository, IQuestionTypeRepository questionTypeRepository)
        {
            _questionRepository = questionRepository;
            _questionTypeRepository = questionTypeRepository;
        }

        public async Task<BaseResponse<QuestionDTO>> StoreQuestion(QuestionRequestModel request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var question = await _questionRepository.GetQuestionByText(request.Text,cancellationToken);
            if(question == null)
            {
                return new BaseResponse<QuestionDTO>
                {
                    Message = "Question does not exist",
                    Status = false,
                };
            }
            question.Text = request.Text;
            question.QuestionType.QuestionName = request.QuestionTypeId;
             await _questionRepository.UpdateQuestion(question, cancellationToken);
            return new BaseResponse<QuestionDTO>
            {
                Data = new QuestionDTO
                {
                    Id = question.Id,
                    Text = question.Text,
                    Options = question.Options,
                    QuestionTypeId = question.QuestionTypeId
                   
                },
                Message = "Successfully updated",
                Status = true
            };

        }

        public async Task<BaseResponse<QuestionDTO>> GetQuestionByQuestionTypeId(string questionTypeId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var question = await _questionRepository.GetQuestionByQuestionTypeId(questionTypeId, cancellationToken);
            if (question == null)
            {
                return new BaseResponse<QuestionDTO>
                {
                    Message = "Cart not found",
                    Status = false
                };
            }

            return new BaseResponse<QuestionDTO>
            {
                Data = new QuestionDTO
                {
                    Id = question.QuestionTypeId,


                },
                Message = "Successfull",
                Status = true
            };
        }

        public async Task<BaseResponse<QuestionDTO>> EditQuestion(UpdateQuestionRequestModel request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(request.QuestionTypeId)) throw new ArgumentNullException(request.QuestionTypeId);
            var question = await _questionRepository.GetQuestionByText(request.Text, cancellationToken);
            if (question == null) return new BaseResponse<QuestionDTO>
            {
                Message = " Question Does not exist",
                Status = false
            };
            question.Options = request.Options;
            question.Text = request.Text;   
            question.QuestionType = request.QuestionType;
            question.QuestionTypeId = request.QuestionTypeId;

            return new BaseResponse<QuestionDTO>
            {
                Message = "Question Sucessfully Updated",
                Status = true,
            };

        }
    }
}

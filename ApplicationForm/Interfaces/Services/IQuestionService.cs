using ApplicationForm.DTOs;

namespace ApplicationForm.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<BaseResponse<QuestionDTO>> StoreQuestion(QuestionRequestModel request, CancellationToken cancellationToken);
        Task<BaseResponse<QuestionDTO>> EditQuestion(UpdateQuestionRequestModel request, CancellationToken cancellationToken);
        Task<BaseResponse<QuestionDTO>> GetQuestionByQuestionTypeId(string questionTypeId, CancellationToken cancellationToken);

    }
}

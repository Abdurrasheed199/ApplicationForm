using ApplicationForm.Models;

namespace ApplicationForm.Interfaces.Repositories
{
    public interface IQuestionTypeRepository
    {
        Task<QuestionType> GetQuestionTypeById(string questionTypeId, CancellationToken cancellationToken);
    }

}

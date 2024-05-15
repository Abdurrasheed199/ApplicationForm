using ApplicationForm.Models;

namespace ApplicationForm.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question> CreateQuestionAsync(Question question, CancellationToken cancellationToken);
        Task<Question> UpdateQuestion(Question question, CancellationToken cancellationToken);
        Task<Question> GetQuestionByText(string text, CancellationToken cancellationToken);
        Task<Question> GetQuestionById(string questionId, CancellationToken cancellationToken);

        Task<Question> GetQuestionByQuestionTypeId(string questionTypeId, CancellationToken cancellationToken);
    }
}

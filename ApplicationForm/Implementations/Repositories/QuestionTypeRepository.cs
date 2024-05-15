using ApplicationForm.Context;
using ApplicationForm.Interfaces.Repositories;
using ApplicationForm.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForm.Implementations.Repositories
{
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly ApplicationContext _context;
        public QuestionTypeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<QuestionType> GetQuestionTypeById(string questionTypeId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(questionTypeId)) throw new ArgumentNullException(nameof(questionTypeId));
            cancellationToken.ThrowIfCancellationRequested();
            var type = await _context.QuestionTypes
                .SingleOrDefaultAsync(sc => sc.Id == questionTypeId, cancellationToken);
            return type;
        }
    }
}

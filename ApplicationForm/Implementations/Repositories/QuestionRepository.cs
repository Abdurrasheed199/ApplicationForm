using ApplicationForm.Context;
using ApplicationForm.Interfaces.Repositories;
using ApplicationForm.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;



namespace ApplicationForm.Implementations.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationContext _context;
        public QuestionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Question> CreateQuestionAsync(Question question, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (question == null) throw new ArgumentNullException(nameof(question));
            await _context.Questions.AddAsync(question, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return question;
        }

        public async Task<Question> GetQuestionByText(string text, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));
            cancellationToken.ThrowIfCancellationRequested();
            var qus = await _context.Questions
                 .Include(q => q.QuestionType)
                .SingleOrDefaultAsync(sc => sc.Text == text, cancellationToken);
            return qus;
        }

        public async Task<Question> GetQuestionByQuestionTypeId(string questionTypeId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (questionTypeId == null) throw new ArgumentNullException(null);
            var newQuestion = await _context.Questions
                .Include(q => q.QuestionType)
                .SingleOrDefaultAsync(p => p.QuestionTypeId == questionTypeId, cancellationToken);
            return newQuestion;
        }

        public async Task<Question> UpdateQuestion(Question question, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (question == null) throw new ArgumentNullException(nameof(question));
            _context.Questions.Update(question);
            await _context.SaveChangesAsync(cancellationToken);
            return question;
        }

        public async Task<Question> GetQuestionById(string questionId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(questionId)) throw new ArgumentNullException(nameof(questionId));
            cancellationToken.ThrowIfCancellationRequested();
            var qus = await _context.Questions
            .Include(q => q.QuestionType)
                .SingleOrDefaultAsync(sc => sc.Id == questionId, cancellationToken);
            return qus;
        }
    }
}

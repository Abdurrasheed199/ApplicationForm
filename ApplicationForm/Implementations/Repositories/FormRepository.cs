using ApplicationForm.Context;
using ApplicationForm.DTOs;
using ApplicationForm.Interfaces.Repositories;
using ApplicationForm.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForm.Implementations.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly ApplicationContext _context;
        public FormRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Form> GetFormByEmail(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));
            var form = await _context.Forms
                .SingleOrDefaultAsync(ac => ac.Email == email, cancellationToken);
            return form;
        }

        public async Task<Form> SaveFormAsync(Form form, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (form == null) throw new ArgumentNullException(nameof(form));
            await _context.Forms.AddAsync(form, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return form;
        }

        public async Task<Form> SaveFormAsync(FormRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(model.Email)) throw new ArgumentNullException(nameof(model.Email));
            cancellationToken.ThrowIfCancellationRequested();
            var form = await _context.Forms
            
                .SingleOrDefaultAsync(sc => sc.Email == model.Email, cancellationToken);
            return form;
        }
    }
}

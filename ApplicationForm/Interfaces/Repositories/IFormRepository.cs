using ApplicationForm.DTOs;
using ApplicationForm.Models;

namespace ApplicationForm.Interfaces.Repositories
{
    public interface IFormRepository
    {
        Task<Form> SaveFormAsync(Form form, CancellationToken cancellationToken);
        Task<Form> SaveFormAsync(FormRequestModel model, CancellationToken cancellationToken);
        Task<Form> GetFormByEmail(string email, CancellationToken cancellationToken);
    }
}

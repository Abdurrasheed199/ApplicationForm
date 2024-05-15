using ApplicationForm.DTOs;

namespace ApplicationForm.Interfaces.Services
{
    public interface IFormService
    {
        Task<BaseResponse<FormDTO>> SaveForm(FormRequestModel request, CancellationToken cancellationToken);
    }
}

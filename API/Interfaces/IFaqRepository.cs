using API.Entities.Requests;
using API.Entities.Responses;

namespace API.Interfaces
{
    public interface IFaqRepository
    {
        Task<FaqResponse> AddFaqAsync(FaqRequest request);

        Task<bool> UpdateFaqAsync(FaqRequest faqRequest);

        Task<bool> DeleteFaqAsync(int id);

        Task<IEnumerable<FaqResponse>> GetAllFaqAsync();

        Task<FaqResponse> GetFaqAsync(int id);
    }
}

using FanPage.Application.Fanfic;
using FanPage.Domain.Entities.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Persistence.Repositories.Interfaces.IFanfic
{
    public interface IFanficRepository
    {
        Task<Fanfic> GetByIdAsync(int id);
        Task<List<Fanfic>> GetByAuthorNameAsync(string id);
        Task<List<Fanfic>> GetAllAsync();
        Task<FanficDto> CreateAsync(CreateDto fanfic);
        Task UpdateAsync(UpdateDto fanfic, int fanficId);
        Task DeleteAsync(int id);
        Task<List<Fanfic>> SearchAsync(string searchString, HttpRequest request);
        Task<ReviewsDto> CreateReviewAsync(int fanficId, ReviewsDto reviewsDto);
        
        Task<ReviewsDto> UpdateReviewAsync(int fanficId, ReviewsDto reviewsDto);

        Task DeleteReviewAsync(int fanficId, string userName);
        
        Task<ReviewsDto> GetReviewByFanficIdAsync(int fanficId, string userName);

        Task<List<ReviewsDto>> GetAllReviewByFanficIdAsync(int fanficId);

        Task<List<ReviewsDto>> GetAllReviewByUserNameAsync(string userName);

        Task<List<ReviewsDto>> GetAllReview();

        Task<double> GetAverageRatingAsync(int fanficId);
        Task SaveChangesAsync();
    }
}
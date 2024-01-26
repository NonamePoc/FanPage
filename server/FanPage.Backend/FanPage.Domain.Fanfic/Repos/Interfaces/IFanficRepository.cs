using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Domain.Fanfic.Repos.Interfaces
{
    public interface IFanficRepository
    {
        Task<Entities.Fanfic> GetByIdAsync(int id);
        Task<List<Entities.Fanfic>> GetByAuthorNameAsync(string id);
        Task<List<Entities.Fanfic>> GetAllAsync();


        Task<FanficDto> CreateAsync(CreateDto fanfic);
        Task UpdateAsync(UpdateDto fanfic, int fanficId);
        Task DeleteAsync(int id);
        Task<List<Entities.Fanfic>> SearchAsync(string searchString, bool originalFandom);
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
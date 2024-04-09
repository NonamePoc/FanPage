using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Domain.Fanfic.Repos.Interfaces
{
    public interface IFanficRepository
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();

        Task RollBackAsync();
        Task<FanficDto> GetByIdAsync(int id);
        Task<List<FanficDto>> GetByAuthorNameAsync(string name, int count);
        Task<List<FanficDto>> GetAllAsync(int count);

        Task<List<FanficDto>> LocalGetAllAsync();

        Task<List<FanficDto>> GetLastCreationDateFanficsAsync(int count);

        Task<List<FanficDto>> GetTopRatingFanficsAsync(int count);

        Task<FanficDto> CreateAsync(CreateDto fanfic, string imageFanfic);
        Task<FanficDto> UpdateBannerAsync(int fanficId, string newBannerImage);

        Task UpdateAsync(UpdateDto fanfic, int fanficId);
        Task DeleteAsync(int id);
        Task<List<FanficDto>> SearchAsync(string searchString, bool originalFandom);
        Task<ReviewsDto> CreateReviewAsync(int fanficId, ReviewsDto reviewsDto);

        Task<ReviewsDto> UpdateReviewAsync(int fanficId, ReviewsDto reviewsDto);

        Task DeleteReviewAsync(int fanficId, string userName);

        Task<ReviewsDto> GetReviewByFanficIdAsync(int fanficId, string userName);

        Task<List<ReviewsDto>> GetAllReviewByFanficIdAsync(int fanficId);

        Task<List<ReviewsDto>> GetAllReviewByUserNameAsync(string userName);

        Task<List<ReviewsDto>> GetAllReview();

        Task<double> GetAverageRatingAsync(int fanficId);

        Task ChangeAvatar(int fanficId, string imageFanfic);
        Task SaveChangesAsync();
    }
}
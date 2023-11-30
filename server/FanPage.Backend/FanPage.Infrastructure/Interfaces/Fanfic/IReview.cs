using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Fanfic;

public interface IReview
{
    Task<ReviewsDto> CreateReviewAsync(int fanficId, ReviewsDto reviewsDto, HttpRequest request);
    
    Task<ReviewsDto> UpdateReviewAsync(int fanficId, ReviewsDto reviewsDto, HttpRequest request);

    Task DeleteReviewAsync(int fanficId, HttpRequest request);
    
    Task<ReviewsDto> GetReviewByFanficIdAsync(int fanficId, string userName);

    Task<List<ReviewsDto>> GetAllReviewByFanficIdAsync(int fanficId);

    Task<List<ReviewsDto>> GetAllReviewByUserNameAsync(string userName);

    Task<List<ReviewsDto>> GetAllReview();
}
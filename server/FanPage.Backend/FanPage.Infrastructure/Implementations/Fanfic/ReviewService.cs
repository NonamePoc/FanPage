using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class ReviewService : IReview
{
    private readonly IJwtTokenManager _jwtTokenManager;
    private readonly IFanficRepository _fanficRepository;

    public ReviewService(IJwtTokenManager jwtTokenManager, IFanficRepository fanficRepository)
    {
        _jwtTokenManager = jwtTokenManager;
        _fanficRepository = fanficRepository;
    }

    public async Task<ReviewsDto> CreateReviewAsync(
        int fanficId,
        ReviewsDto reviewsDto,
        HttpRequest request
    )
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);

        reviewsDto.UserName = userName;
        if (fanfic == null)
        {
            throw new FanficException($"Error review");
        }

        var reviewAlready = await _fanficRepository.GetReviewByFanficIdAsync(fanficId, userName);

        if (reviewAlready != null)
        {
            throw new FanficException($"You already left a review");
        }

        var result = await _fanficRepository.CreateReviewAsync(fanficId, reviewsDto);

        return new ReviewsDto()
        {
            FanficId = fanficId,
            ReviewId = result.ReviewId,
            Text = result.Text,
            CreationDate = result.CreationDate,
            UserName = userName,
            Rating = result.Rating,
        };
    }

    public async Task<ReviewsDto> UpdateReviewAsync(
        int fanficId,
        ReviewsDto reviewsDto,
        HttpRequest request
    )
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var review = await _fanficRepository.GetReviewByFanficIdAsync(fanficId, userName);
        reviewsDto.UserName = userName;

        if (fanfic == null)
        {
            throw new FanficException($"Error review");
        }

        if (reviewsDto.UserName != userName)
        {
            throw new FanficException($"You can't update this review");
        }

        review.Text = !string.IsNullOrWhiteSpace(reviewsDto.Text) ? reviewsDto.Text : review.Text;
        review.Rating = (reviewsDto.Rating != 0) ? reviewsDto.Rating : review.Rating;

        var result = await _fanficRepository.UpdateReviewAsync(fanficId, review);

        return new ReviewsDto()
        {
            FanficId = fanficId,
            ReviewId = result.ReviewId,
            Text = result.Text,
            CreationDate = result.CreationDate,
            UserName = userName,
            Rating = result.Rating,
        };
    }

    public async Task DeleteReviewAsync(int fanficId, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var review = await _fanficRepository.GetReviewByFanficIdAsync(fanficId, userName);

        if (fanfic == null)
        {
            throw new FanficException($"Error review");
        }

        if (review.UserName != userName)
        {
            throw new FanficException($"You can't delete this review");
        }

        await _fanficRepository.DeleteReviewAsync(fanficId, userName);
    }

    public async Task<ReviewsDto> GetReviewByFanficIdAsync(int fanficId, string userName)
    {
        var result = await _fanficRepository.GetReviewByFanficIdAsync(fanficId, userName);

        return new ReviewsDto()
        {
            FanficId = fanficId,
            ReviewId = result.ReviewId,
            Text = result.Text,
            CreationDate = result.CreationDate,
            UserName = userName,
            Rating = result.Rating,
        };
    }

    public async Task<List<ReviewsDto>> GetAllReviewByFanficIdAsync(int fanficId)
    {
        var reviews = await _fanficRepository.GetAllReviewByFanficIdAsync(fanficId);
        var result = reviews
            .Select(s => new ReviewsDto()
            {
                FanficId = fanficId,
                ReviewId = s.ReviewId,
                Text = s.Text,
                CreationDate = s.CreationDate,
                UserName = s.UserName,
                Rating = s.Rating,
            })
            .ToList();

        return result;
    }

    public async Task<List<ReviewsDto>> GetAllReviewByUserNameAsync(string userName)
    {
        var reviews = await _fanficRepository.GetAllReviewByUserNameAsync(userName);
        var result = reviews
            .Select(s => new ReviewsDto()
            {
                FanficId = s.FanficId,
                ReviewId = s.ReviewId,
                Text = s.Text,
                CreationDate = s.CreationDate,
                UserName = userName,
                Rating = s.Rating,
            })
            .ToList();

        return result;
    }

    public async Task<List<ReviewsDto>> GetAllReview()
    {
        var reviews = await _fanficRepository.GetAllReview();
        var result = reviews
            .Select(s => new ReviewsDto()
            {
                FanficId = s.FanficId,
                ReviewId = s.ReviewId,
                Text = s.Text,
                CreationDate = s.CreationDate,
                UserName = s.UserName,
                Rating = s.Rating,
            })
            .ToList();

        return result;
    }
}

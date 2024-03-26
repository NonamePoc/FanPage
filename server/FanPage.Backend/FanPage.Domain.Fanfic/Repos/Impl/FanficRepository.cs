using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Context;
using FanPage.Domain.Fanfic.Entities;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Fanfic.Repos.Impl;

public class FanficRepository : RepositoryBase<Entities.Fanfic>, IFanficRepository
{
    private readonly FanficContext _fanficContext;
    private readonly IMapper _mapper;

    public FanficRepository(FanficContext fanficContext, IMapper mapper)
        : base(fanficContext)
    {
        _fanficContext = fanficContext;
        _mapper = mapper;
    }

    public async Task BeginTransactionAsync()
    {
        await _fanficContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _fanficContext.Database.CommitTransactionAsync();
    }

    public async Task RollBackAsync()
    {
        await _fanficContext.Database.RollbackTransactionAsync();
    }

    public async Task<double> GetAverageRatingAsync(int fanficId)
    {
        var reviews = await _fanficContext.Reviews.Where(x => x.FanficId == fanficId).ToListAsync();
        if (reviews.Count == 0)
        {
            return 0;
        }

        return reviews.Average(x => x.Rating);
    }

    public async Task<FanficDto> GetByIdAsync(int id)
    {
        var fanfic =
            await _fanficContext
                .Fanfic.Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(ft => ft.Reviews)
                .Include(fanfic => fanfic.Photos)
                .FirstOrDefaultAsync(f => f.FanficId == id)
            ?? throw new FanficException("Fanfic not found");

        return MapFanficEntityToDto(fanfic);
    }

    public async Task<List<FanficDto>> GetByAuthorNameAsync(string name, int count)
    {
        var fanficEntities = await _fanficContext
            .Fanfic.Include(f => f.FanficCategories)
            .ThenInclude(fc => fc.Category)
            .Include(f => f.FanficTags)
            .ThenInclude(ft => ft.Tag)
            .Include(f => f.Chapters)
            .Include(f => f.Reviews)
            .Include(f => f.Photos)
            .Take(count)
            .Where(w => w.AuthorName == name)
            .ToListAsync();

        return fanficEntities.Select(MapFanficEntityToDto).ToList();
    }

    public async Task<List<FanficDto>> GetAllAsync(int count)
    {
        var fanficEntities = await _fanficContext
            .Fanfic.Include(f => f.FanficCategories)
            .ThenInclude(fc => fc.Category)
            .Include(f => f.FanficTags)
            .ThenInclude(ft => ft.Tag)
            .Include(f => f.Chapters)
            .Include(f => f.Photos)
            .Include(f => f.Reviews)
            .Take(count)
            .ToListAsync();

        return fanficEntities.Select(MapFanficEntityToDto).ToList();
    }

    public async Task<List<FanficDto>> LocalGetAllAsync()
    {
        var fanficEntities = await _fanficContext
            .Fanfic.Include(f => f.FanficCategories)
            .ThenInclude(fc => fc.Category)
            .Include(f => f.FanficTags)
            .ThenInclude(ft => ft.Tag)
            .Include(f => f.Chapters)
            .Include(f => f.Photos)
            .Include(f => f.Reviews)
            .ToListAsync();

        return fanficEntities.Select(MapFanficEntityToDto).ToList();
    }

    public async Task<FanficDto> CreateAsync(CreateDto fanficDto, string imageFanfic)
    {
        imageFanfic ??= " ";
        var fanficEntity = new Entities.Fanfic
        {
            AuthorName = fanficDto.AuthorName,
            Title = fanficDto.Title,
            Description = fanficDto.Description,
            OriginFandom = fanficDto.OriginFandom,
            Stage = fanficDto.Stage!,
            Language = fanficDto.Language!,
            CreationDate = DateTimeOffset.UtcNow,
            Photos = imageFanfic != null
                ? new List<FanficPhoto> { new() { Image = imageFanfic } }
                : new List<FanficPhoto>(),
        };

        var createdFanfic = await _fanficContext.Fanfic.AddAsync(fanficEntity);
        await _fanficContext.SaveChangesAsync();

        return MapFanficEntityToDto(createdFanfic.Entity);
    }

    public async Task UpdateAsync(UpdateDto update, int fanficId)
    {
        var fanfic = await _fanficContext
            .Fanfic.Include(f => f.Photos)
            .FirstOrDefaultAsync(f => f.FanficId == fanficId);

        fanfic.Title = update.Title;
        fanfic.Description = update.Description;
        fanfic.OriginFandom = (bool)update.OriginFandom;
        fanfic.Stage = update.Stage!;
        fanfic.Language = update.Language!;
        fanfic!.CreationDate = DateTimeOffset.UtcNow;

        _fanficContext.Fanfic.Update(fanfic);
        await _fanficContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var fanfic = await _fanficContext.Fanfic.FindAsync(id);
        _fanficContext.Fanfic.Remove(fanfic);
        await _fanficContext.SaveChangesAsync();
    }

    public async Task<List<FanficDto>> SearchAsync(string searchString, bool originalFandom)
    {
        var searchWords = searchString.Split(' ');

        var query = _fanficContext
            .Fanfic.Include(f => f.FanficCategories)
            .ThenInclude(fc => fc.Category)
            .Include(f => f.FanficTags)
            .ThenInclude(ft => ft.Tag)
            .Include(f => f.Chapters)
            .Include(f => f.Photos)
            .Include(f => f.Reviews)
            .AsQueryable();

        query = searchWords.Aggregate(
            query,
            (current, searchWord) =>
                current.Where(w =>
                    w.Description != null
                    && (
                        w.Title.Contains(searchWord)
                        || w.FanficTags.Any(a =>
                            a.Tag.Name != null && a.Tag.Name.Contains(searchWord)
                        )
                        || w.FanficCategories.Any(a =>
                            a.Category.Name != null && a.Category.Name.Contains(searchWord)
                        )
                        || w.Description.Contains(searchWord)
                        || w.AuthorName.Contains(searchWord)
                        || w.Language.Contains(searchWord)
                        || w.Chapters.Any(a =>
                            a.Title.Contains(searchWord) || a.Content.Contains(searchWord)
                        )
                        || w.Reviews.Any(a =>
                            a.Text.Contains(searchWord) || a.UserName.Contains(searchWord)
                        )
                    )
                )
        );

        if (originalFandom)
        {
            query = query.Where(w => w.OriginFandom == true);
        }

        return query.AsEnumerable().Select(MapFanficEntityToDto).ToList();
    }

    public async Task<ReviewsDto> CreateReviewAsync(int fanficId, ReviewsDto reviewsDto)
    {
        var reviewEntity = _mapper.Map<Reviews>(reviewsDto);
        reviewEntity.CreationDate = DateTimeOffset.UtcNow;
        reviewEntity.FanficId = fanficId;
        var createdReview = _fanficContext.Reviews.Add(reviewEntity);
        await _fanficContext.SaveChangesAsync();
        return _mapper.Map<ReviewsDto>(createdReview.Entity);
    }

    public async Task<ReviewsDto> UpdateReviewAsync(int fanficId, ReviewsDto reviewsDto)
    {
        var reviewEntity = _context.Reviews.FirstOrDefault(x =>
            x.FanficId == fanficId && x.UserName == reviewsDto.UserName
        );

        reviewEntity.CreationDate = DateTimeOffset.UtcNow;
        reviewEntity.FanficId = fanficId;
        reviewEntity.Text = reviewsDto.Text;
        reviewEntity.Rating = reviewsDto.Rating;

        _fanficContext.Reviews.Update(reviewEntity);
        await _fanficContext.SaveChangesAsync();
        return _mapper.Map<ReviewsDto>(reviewEntity);
    }

    public async Task DeleteReviewAsync(int fanficId, string userName)
    {
        var review = await _fanficContext.Reviews.FirstOrDefaultAsync(x =>
            x.FanficId == fanficId && x.UserName == userName
        );
        _fanficContext.Reviews.Remove(review);
        await _fanficContext.SaveChangesAsync();
    }

    public async Task<ReviewsDto> GetReviewByFanficIdAsync(int fanficId, string userName)
    {
        var review = await _fanficContext
            .Reviews.AsNoTracking()
            .FirstOrDefaultAsync(x => x.FanficId == fanficId && x.UserName == userName);
        return _mapper.Map<ReviewsDto>(review);
    }

    public async Task<List<ReviewsDto>> GetAllReviewByFanficIdAsync(int fanficId)
    {
        var review = await _fanficContext.Reviews.Where(x => x.FanficId == fanficId).ToListAsync();
        return _mapper.Map<List<ReviewsDto>>(review);
    }

    public async Task<List<ReviewsDto>> GetAllReview()
    {
        var review = await _fanficContext.Reviews.ToListAsync();
        return _mapper.Map<List<ReviewsDto>>(review);
    }

    public async Task<List<ReviewsDto>> GetAllReviewByUserNameAsync(string userName)
    {
        var review = await _fanficContext.Reviews.Where(x => x.UserName == userName).ToListAsync();
        return _mapper.Map<List<ReviewsDto>>(review);
    }

    public async Task<List<FanficDto>> GetTopRatingFanficsAsync(int count)
    {
        var fanfics = await _fanficContext
            .Fanfic.Include(f => f.FanficCategories)
            .ThenInclude(fc => fc.Category)
            .Include(f => f.FanficTags)
            .ThenInclude(ft => ft.Tag)
            .Include(f => f.Chapters)
            .Include(f => f.Photos)
            .Include(f => f.Reviews)
            .OrderByDescending(x => x.Reviews.Select(s => s.Rating).Average())
            .Take(count)
            .ToListAsync();

        return fanfics.Select(MapFanficEntityToDto).ToList();
    }

    public async Task<List<FanficDto>> GetLastCreationDateFanficsAsync(int count)
    {
        var fanfics = await _fanficContext
            .Fanfic.Include(f => f.FanficCategories)
            .ThenInclude(fc => fc.Category)
            .Include(f => f.FanficTags)
            .ThenInclude(ft => ft.Tag)
            .Include(f => f.Chapters)
            .Include(f => f.Photos)
            .Include(f => f.Reviews)
            .OrderByDescending(x => x.CreationDate)
            .Take(count)
            .ToListAsync();

        return fanfics.Select(MapFanficEntityToDto).ToList();
    }

    public async Task SaveChangesAsync()
    {
        await _fanficContext.SaveChangesAsync();
    }

    private static FanficDto MapFanficEntityToDto(Entities.Fanfic fanficEntity)
    {
        return new FanficDto
        {
            Id = fanficEntity.FanficId,
            AuthorName = fanficEntity.AuthorName,
            Title = fanficEntity.Title,
            Description = fanficEntity.Description,
            OriginFandom = fanficEntity.OriginFandom,
            Stage = fanficEntity.Stage,
            Language = fanficEntity.Language,
            CreationDate = fanficEntity.CreationDate,
            Image = fanficEntity.Photos.FirstOrDefault()?.Image,
            Categories = fanficEntity
                .FanficCategories?.Select(fc => new CategoryDto
                {
                    Name = fc.Category.Name,
                    CategoryId = fc.Category.CategoryId
                })
                .ToList(),
            Tags = fanficEntity
                .FanficTags?.Select(ft => new TagDto
                {
                    Name = ft.Tag.Name,
                    TagId = ft.Tag.TagId,
                    IsApproved = ft.Tag.IsApproved
                })
                .ToList(),
            Chapters = fanficEntity
                .Chapters?.Select(chapter => new ChapterDto
                {
                    FanficId = fanficEntity.FanficId,
                    Title = chapter.Title,
                    Content = chapter.Content
                })
                .ToList(),
            Reviews = fanficEntity
                .Reviews?.Select(review => new ReviewsDto
                {
                    FanficId = fanficEntity.FanficId,
                    ReviewId = review.ReviewId,
                    Text = review.Text,
                    CreationDate = review.CreationDate,
                    UserName = review.UserName,
                    Rating = review.Rating
                })
                .Where(review => review.FanficId == fanficEntity.FanficId)
                .ToList()
        };
    }

    public async Task ChangeAvatar(int fanficId, string imageFanfic)
    {
        var fanfic = await _fanficContext.Fanfic.FirstOrDefaultAsync(x => x.FanficId == fanficId);

        if (fanfic == null)
        {
            throw new FanficException("Fanfic not found");
        }

        fanfic.Photos = new List<FanficPhoto> { new() { Image = imageFanfic } };

        await _fanficContext.SaveChangesAsync();
    }
}
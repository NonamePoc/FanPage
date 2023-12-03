using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Entities.Fanfic;
using FanPage.Exceptions;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces.IFanfic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FanficException = FanPage.Exceptions.FanficException;

namespace FanPage.Persistence.Repositories.Implementations.FanficRepos
{
    public class FanficRepository : RepositoryBase<Fanfic>, IFanficRepository
    {
        private readonly FanficContext _fanficContext;
        private readonly IMapper _mapper;

        public FanficRepository(FanficContext fanficContext, IMapper mapper) : base(
            fanficContext)
        {
            _fanficContext = fanficContext;
            _mapper = mapper;
        }

        public async Task<double> GetAverageRatingAsync(int fanficId)
        {
            var reviews = await _fanficContext.Reviews.Where(x => x.FanficId == fanficId).ToListAsync();

            return reviews.Average(x => x.Rating);
        }

        public async Task<Fanfic> GetByIdAsync(int id)
        {
            return await _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(ft => ft.Reviews)
                .FirstOrDefaultAsync(f => f.FanficId == id) ?? throw new FanficException("Fanfic not found");
        }

        public async Task<List<Fanfic>> GetByAuthorNameAsync(string name)
        {
            return await _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(f => f.Reviews)
                .Where(w => w.AuthorName == name).ToListAsync();
        }

        public async Task<List<Fanfic>> GetAllAsync()
        {
            return await _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(f => f.Photos)
                .Include(f => f.Reviews)
                .ToListAsync();
        }

        public async Task<FanficDto> CreateAsync(CreateDto fanficDto)
        {
            var fanfic = _mapper.Map<Fanfic>(fanficDto);
            fanfic.CreationDate = DateTimeOffset.UtcNow;
            var createdFanfic = _context.Fanfic.Add(fanfic);
            await _context.SaveChangesAsync();
            return _mapper.Map<FanficDto>(createdFanfic.Entity);
        }

        public async Task UpdateAsync(UpdateDto update, int fanficId)
        {
            var fanfic = await _fanficContext.Fanfic.Include(f => f.Photos)
                .FirstOrDefaultAsync(f => f.FanficId == fanficId);

            _mapper.Map(update, fanfic);
            fanfic.CreationDate = DateTimeOffset.UtcNow;

            if (fanfic.Photos != null)
            {
                _fanficContext.FanficPhotos.RemoveRange(fanfic.Photos);
                await _fanficContext.SaveChangesAsync();
            }

            if (fanfic.Photos == null)
            {
                fanfic.Photos = new List<FanficPhoto>();
            }

            if (update.Photo != null)
            {
                foreach (var photo in update.Photo)
                {
                    fanfic.Photos.Add(new FanficPhoto { FanficId = fanficId, Image = photo.Image });
                }
            }

            await _fanficContext.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var fanfic = await _fanficContext.Fanfic.FindAsync(id);
            _fanficContext.Fanfic.Remove(fanfic);
            await _fanficContext.SaveChangesAsync();
        }

        public async Task<List<Fanfic>> SearchAsync(string searchString, HttpRequest request)
        {
            var searchWords = searchString.Split(' ');

            var query = _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(f => f.Photos)
                .Include(f => f.Reviews)
                .AsQueryable();

            foreach (var searchWord in searchWords)
            {
                query = query.Where(w =>
                    EF.Functions.Like(w.Title, $"%{searchWord}%") ||
                    w.FanficTags.Any(a => EF.Functions.Like(a.Tag.Name, $"%{searchWord}%")) ||
                    w.FanficCategories.Any(a => EF.Functions.Like(a.Category.Name, $"%{searchWord}%")) ||
                    EF.Functions.Like(w.Description, $"%{searchWord}%") ||
                    EF.Functions.Like(w.AuthorName, $"%{searchWord}%") ||
                    EF.Functions.Like(w.Language, $"%{searchWord}%") ||
                    w.Chapters.Any(a =>
                        EF.Functions.Like(a.Title, $"%{searchWord}%") ||
                        EF.Functions.Like(a.Content, $"%{searchWord}%")) ||
                    w.Reviews.Any(a =>
                        EF.Functions.Like(a.Text, $"%{searchWord}%") ||
                        EF.Functions.Like(a.UserName, $"%{searchWord}%"))
                );
            }

            if (searchWords.Any(w => bool.TryParse(w, out _)))
            {
                var boolSearchValue = searchWords.First(w => bool.TryParse(w, out _));
                query = query.Where(w => w.OriginFandom == bool.Parse(boolSearchValue));
            }

            var result = await query.ToListAsync();
            return result;
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
            var reviewEntity = _mapper.Map<Reviews>(reviewsDto);
            reviewEntity.CreationDate = DateTimeOffset.UtcNow;
            reviewEntity.FanficId = fanficId;

            _fanficContext.Reviews.Update(reviewEntity);
            await _fanficContext.SaveChangesAsync();
            return _mapper.Map<ReviewsDto>(reviewEntity);
        }

        public async Task DeleteReviewAsync(int fanficId, string userName)
        {
            var review = await _fanficContext.Reviews.FirstOrDefaultAsync(x =>
                x.FanficId == fanficId && x.UserName == userName);
            _fanficContext.Reviews.Remove(review);
            await _fanficContext.SaveChangesAsync();
        }

        public async Task<ReviewsDto> GetReviewByFanficIdAsync(int fanficId, string userName)
        {
            var review =
                await _fanficContext.Reviews.AsNoTracking()
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

        public async Task SaveChangesAsync()
        {
            await _fanficContext.SaveChangesAsync();
        }
    }
}
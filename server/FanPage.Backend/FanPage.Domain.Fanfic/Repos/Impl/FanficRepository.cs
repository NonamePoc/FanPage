using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Context;
using FanPage.Domain.Fanfic.Entities;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Fanfic.Repos.Impl
{
    public class FanficRepository : RepositoryBase<Entities.Fanfic>, IFanficRepository
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

        public async Task<FanficDto> GetByIdAsync(int id)
        {
            var fanfic = await _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(ft => ft.Reviews).Include(fanfic => fanfic.Photos)
                .FirstOrDefaultAsync(f => f.FanficId == id) ?? throw new FanficException("Fanfic not found");

            var list = new FanficDto
            {
                Id = fanfic.FanficId,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Image = fanfic.Photos.FirstOrDefault()?.Image,
                Categories = fanfic.FanficCategories.Select(fc => new CategoryDto
                {
                    Name = fc.Category.Name,
                    CategoryId = fc.Category.CategoryId
                }).ToList(),
                Tags = fanfic.FanficTags.Select(ft => new TagDto
                {
                    Name = ft.Tag.Name,
                    TagId = ft.Tag.TagId,
                    IsApproved = ft.Tag.IsApproved
                }).ToList(),
                Chapters = fanfic.Chapters.Select(chapter => new ChapterDto
                {
                    FanficId = fanfic.FanficId,
                    Title = chapter.Title,
                    Content = chapter.Content
                }).ToList(),
                Reviews = fanfic.Reviews.Select(review => new ReviewsDto
                {
                    FanficId = fanfic.FanficId,
                    ReviewId = review.ReviewId,
                    Text = review.Text,
                    CreationDate = review.CreationDate,
                    UserName = review.UserName,
                    Rating = review.Rating
                }).Where(review => review.FanficId == fanfic.FanficId).ToList()
            };
            return list;
        }

        public async Task<List<FanficDto>> GetByAuthorNameAsync(string name, int count)
        {
            var fanfic = await _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(f => f.Reviews).Include(fanfic => fanfic.Photos)
                .Take(count)
                .Where(w => w.AuthorName == name).ToListAsync();

            var list = fanfic.Select(fanfic1 => new FanficDto
            {
                Id = fanfic1.FanficId,
                AuthorName = fanfic1.AuthorName,
                Title = fanfic1.Title,
                Description = fanfic1.Description,
                OriginFandom = fanfic1.OriginFandom,
                Stage = fanfic1.Stage,
                Language = fanfic1.Language,
                CreationDate = fanfic1.CreationDate,
                Image = fanfic1.Photos.FirstOrDefault()?.Image,
                Categories = fanfic1.FanficCategories.Select(fc => new CategoryDto
                {
                    Name = fc.Category.Name,
                    CategoryId = fc.Category.CategoryId
                }).ToList(),
                Tags = fanfic1.FanficTags.Select(ft => new TagDto
                {
                    Name = ft.Tag.Name,
                    TagId = ft.Tag.TagId,
                    IsApproved = ft.Tag.IsApproved
                }).ToList(),
                Chapters = fanfic1.Chapters.Select(chapter => new ChapterDto
                {
                    FanficId = fanfic1.FanficId,
                    Title = chapter.Title,
                    Content = chapter.Content
                }).ToList(),
                Reviews = fanfic1.Reviews.Select(review => new ReviewsDto
                {
                    FanficId = fanfic1.FanficId,
                    ReviewId = review.ReviewId,
                    Text = review.Text,
                    CreationDate = review.CreationDate,
                    UserName = review.UserName,
                    Rating = review.Rating
                }).Where(review => review.FanficId == fanfic1.FanficId).ToList()
            }).ToList();
            return list;
        }

        public async Task<List<FanficDto>> GetAllAsync(int count)
        {
            var fanfic = await _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(f => f.Photos)
                .Include(f => f.Reviews)
                .Take(count)
                .ToListAsync();

            var list = fanfic.Select(fanfic1 => new FanficDto
            {
                Id = fanfic1.FanficId,
                AuthorName = fanfic1.AuthorName,
                Title = fanfic1.Title,
                Description = fanfic1.Description,
                OriginFandom = fanfic1.OriginFandom,
                Stage = fanfic1.Stage,
                Language = fanfic1.Language,
                CreationDate = fanfic1.CreationDate,
                Image = fanfic1.Photos.FirstOrDefault()?.Image,
                Categories = fanfic1.FanficCategories.Select(fc => new CategoryDto
                {
                    Name = fc.Category.Name,
                    CategoryId = fc.Category.CategoryId
                }).ToList(),
                Tags = fanfic1.FanficTags.Select(ft => new TagDto
                {
                    Name = ft.Tag.Name,
                    TagId = ft.Tag.TagId,
                    IsApproved = ft.Tag.IsApproved
                }).ToList(),
                Chapters = fanfic1.Chapters.Select(chapter => new ChapterDto
                {
                    FanficId = fanfic1.FanficId,
                    Title = chapter.Title,
                    Content = chapter.Content
                }).ToList(),
                Reviews = fanfic1.Reviews.Select(review => new ReviewsDto
                {
                    FanficId = fanfic1.FanficId,
                    ReviewId = review.ReviewId,
                    Text = review.Text,
                    CreationDate = review.CreationDate,
                    UserName = review.UserName,
                    Rating = review.Rating
                }).Where(review => review.FanficId == fanfic1.FanficId).ToList()
            }).ToList();

            return list;
        }

        public async Task<List<FanficDto>> LocalGetAllAsync()
        {
            var fanfic = await _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(f => f.Photos)
                .Include(f => f.Reviews)
                .ToListAsync();

            var list = fanfic.Select(fanfic1 => new FanficDto
            {
                Id = fanfic1.FanficId,
                AuthorName = fanfic1.AuthorName,
                Title = fanfic1.Title,
                Description = fanfic1.Description,
                OriginFandom = fanfic1.OriginFandom,
                Stage = fanfic1.Stage,
                Language = fanfic1.Language,
                CreationDate = fanfic1.CreationDate,
                Image = fanfic1.Photos.FirstOrDefault()?.Image,
                Categories = fanfic1.FanficCategories.Select(fc => new CategoryDto
                {
                    Name = fc.Category.Name,
                    CategoryId = fc.Category.CategoryId
                }).ToList(),
                Tags = fanfic1.FanficTags.Select(ft => new TagDto
                {
                    Name = ft.Tag.Name,
                    TagId = ft.Tag.TagId,
                    IsApproved = ft.Tag.IsApproved
                }).ToList(),
                Chapters = fanfic1.Chapters.Select(chapter => new ChapterDto
                {
                    FanficId = fanfic1.FanficId,
                    Title = chapter.Title,
                    Content = chapter.Content
                }).ToList(),
                Reviews = fanfic1.Reviews.Select(review => new ReviewsDto
                {
                    FanficId = fanfic1.FanficId,
                    ReviewId = review.ReviewId,
                    Text = review.Text,
                    CreationDate = review.CreationDate,
                    UserName = review.UserName,
                    Rating = review.Rating
                }).Where(review => review.FanficId == fanfic1.FanficId).ToList()
            }).ToList();

            return list;
        }

        public async Task<FanficDto> CreateAsync(CreateDto fanficDto)
        {
            var fanfic = _mapper.Map<Entities.Fanfic>(fanficDto);
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
            fanfic!.CreationDate = DateTimeOffset.UtcNow;

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

        public async Task<List<FanficDto>> SearchAsync(string searchString, bool originalFandom)
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

            query = searchWords.Aggregate(query,
                (current, searchWord) => current.Where(w =>
                    w.Title.Contains(searchWord) ||
                    w.FanficTags.Any(a => a.Tag.Name.Contains(searchWord)) ||
                    w.FanficCategories.Any(a => a.Category.Name.Contains(searchWord)) ||
                    w.Description.Contains(searchWord) ||
                    w.AuthorName.Contains(searchWord) ||
                    w.Language.Contains(searchWord) ||
                    w.Chapters.Any(a =>
                        a.Title.Contains(searchWord) ||
                        a.Content.Contains(searchWord)) ||
                    w.Reviews.Any(a =>
                        a.Text.Contains(searchWord) ||
                        a.UserName.Contains(searchWord))));

            // Додано умову для пошуку за булевою змінною "originalFandom"
            if (originalFandom)
            {
                query = query.Where(w => w.OriginFandom == true);
            }

            var result = await query.ToListAsync();
            var fanficDto = query.Select(result => new FanficDto
            {
                Id = result.FanficId,
                AuthorName = result.AuthorName,
                Title = result.Title,
                Description = result.Description,
                OriginFandom = result.OriginFandom,
                Stage = result.Stage,
                Language = result.Language,
                CreationDate = result.CreationDate,
                Image = result.Photos.FirstOrDefault() != null ? result.Photos.FirstOrDefault().Image : null,
                Categories = result.FanficCategories.Select(fc => new CategoryDto
                {
                    Name = fc.Category.Name,
                    CategoryId = fc.Category.CategoryId
                }).ToList(),
                Tags = result.FanficTags.Select(ft => new TagDto
                {
                    Name = ft.Tag.Name,
                    TagId = ft.Tag.TagId,
                    IsApproved = ft.Tag.IsApproved
                }).ToList(),
                Chapters = result.Chapters.Select(chapter => new ChapterDto
                {
                    FanficId = result.FanficId,
                    Title = chapter.Title,
                    Content = chapter.Content
                }).ToList(),
                Reviews = result.Reviews.Select(review => new ReviewsDto
                {
                    FanficId = result.FanficId,
                    ReviewId = review.ReviewId,
                    Text = review.Text,
                    CreationDate = review.CreationDate,
                    UserName = review.UserName,
                    Rating = review.Rating
                }).Where(review => review.FanficId == result.FanficId).ToList()
            }).ToList();

            return fanficDto;
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

        public async Task<List<FanficDto>> GetTopRatingFanficsAsync(int count)
        {
            var fanfics = await _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(f => f.Photos)
                .Include(f => f.Reviews)
                .OrderByDescending(x => x.Reviews.Select(s => s.Rating).Average())
                .Take(count)
                .ToListAsync();

            var fanficDtos = fanfics.Select(fanfic1 => new FanficDto
            {
                Id = fanfic1.FanficId,
                AuthorName = fanfic1.AuthorName,
                Title = fanfic1.Title,
                Description = fanfic1.Description,
                OriginFandom = fanfic1.OriginFandom,
                Stage = fanfic1.Stage,
                Language = fanfic1.Language,
                CreationDate = fanfic1.CreationDate,
                Image = fanfic1.Photos.FirstOrDefault()?.Image,
                Categories = fanfic1.FanficCategories.Select(fc => new CategoryDto
                {
                    Name = fc.Category.Name,
                    CategoryId = fc.Category.CategoryId
                }).ToList(),
                Tags = fanfic1.FanficTags.Select(ft => new TagDto
                {
                    Name = ft.Tag.Name,
                    TagId = ft.Tag.TagId,
                    IsApproved = ft.Tag.IsApproved
                }).ToList(),
                Chapters = fanfic1.Chapters.Select(chapter => new ChapterDto
                {
                    FanficId = fanfic1.FanficId,
                    Title = chapter.Title,
                    Content = chapter.Content
                }).ToList(),
                Reviews = fanfic1.Reviews.Select(review => new ReviewsDto
                {
                    FanficId = fanfic1.FanficId,
                    ReviewId = review.ReviewId,
                    Text = review.Text,
                    CreationDate = review.CreationDate,
                    UserName = review.UserName,
                    Rating = review.Rating
                }).Where(review => review.FanficId == fanfic1.FanficId).ToList()
            }).ToList();

            return fanficDtos;
        }

        public async Task<List<FanficDto>> GetLastCreationDateFanficsAsync(int count)
        {
            var fanfics = await _fanficContext.Fanfic
                .Include(f => f.FanficCategories)
                .ThenInclude(fc => fc.Category)
                .Include(f => f.FanficTags)
                .ThenInclude(ft => ft.Tag)
                .Include(f => f.Chapters)
                .Include(f => f.Photos)
                .Include(f => f.Reviews)
                .OrderByDescending(x => x.CreationDate)
                .Take(count)
                .ToListAsync();

            var fanficDtos = fanfics.Select(fanfic1 => new FanficDto
            {
                Id = fanfic1.FanficId,
                AuthorName = fanfic1.AuthorName,
                Title = fanfic1.Title,
                Description = fanfic1.Description,
                OriginFandom = fanfic1.OriginFandom,
                Stage = fanfic1.Stage,
                Language = fanfic1.Language,
                CreationDate = fanfic1.CreationDate,
                Image = fanfic1.Photos.FirstOrDefault()?.Image,
                Categories = fanfic1.FanficCategories.Select(fc => new CategoryDto
                {
                    Name = fc.Category.Name,
                    CategoryId = fc.Category?.CategoryId ?? 0
                }).ToList(),
                Tags = fanfic1.FanficTags.Select(ft => new TagDto
                {
                    Name = ft.Tag.Name,
                    TagId = ft.Tag.TagId,
                    IsApproved = ft.Tag.IsApproved
                }).ToList(),
                Chapters = fanfic1.Chapters.Select(chapter => new ChapterDto
                {
                    FanficId = fanfic1.FanficId,
                    Title = chapter.Title,
                    Content = chapter.Content
                }).ToList(),
                Reviews = fanfic1.Reviews.Select(review => new ReviewsDto
                {
                    FanficId = fanfic1.FanficId,
                    ReviewId = review.ReviewId,
                    Text = review.Text,
                    CreationDate = review.CreationDate,
                    UserName = review.UserName,
                    Rating = review.Rating
                }).Where(review => review.FanficId == fanfic1.FanficId).ToList()
            }).ToList();

            return fanficDtos;
        }


        public async Task SaveChangesAsync()
        {
            await _fanficContext.SaveChangesAsync();
        }
    }
}
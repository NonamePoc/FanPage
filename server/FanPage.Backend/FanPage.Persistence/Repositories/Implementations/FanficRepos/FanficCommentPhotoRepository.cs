using AutoMapper;
using FanPage.Domain.Entities.Fanfic;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces.IFanfic;


namespace FanPage.Persistence.Repositories.Implementations.FanficRepos
{
    public class FanficCommentPhotoRepository : RepositoryBase<CommentPhoto>, IFanficCommentRepository
    {
        private readonly FanficContext _context;
        private readonly IMapper _mapper;

        public FanficCommentPhotoRepository(IMapper mapper, FanficContext context) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task CreateAsync(CommentPhoto fanficComment)
        {
            var fanficPhotoEntity = _mapper.Map<CommentPhoto>(fanficComment);
            _context.CommentPhotos.Add(fanficPhotoEntity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            var fanficPhoto = _context.CommentPhotos.FirstOrDefault(x => x.Id == id);
            _context.CommentPhotos.Remove(fanficPhoto);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(CommentPhoto fanficComment)
        {
            var fanficPhotoEntity = _mapper.Map<CommentPhoto>(fanficComment);
            _context.CommentPhotos.Update(fanficPhotoEntity);
            return _context.SaveChangesAsync();
        }
    }
}
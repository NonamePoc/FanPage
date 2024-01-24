using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Context;
using FanPage.Domain.Fanfic.Entities;
using FanPage.Domain.Fanfic.Repos.Interfaces;

namespace FanPage.Domain.Fanfic.Repos.Impl
{
    public class CommentPhotoRepository : RepositoryBase<CommentPhoto>, ICommentPhotoRepository
    {
        private readonly FanficContext _context;
        private readonly IMapper _mapper;

        public CommentPhotoRepository(IMapper mapper, FanficContext context) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task CreateAsync(CommentPhotoDto fanficComment)
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

        public Task UpdateAsync(CommentPhotoDto fanficComment)
        {
            var fanficPhotoEntity = _mapper.Map<CommentPhoto>(fanficComment);
            _context.CommentPhotos.Update(fanficPhotoEntity);
            return _context.SaveChangesAsync();
        }
    }
}
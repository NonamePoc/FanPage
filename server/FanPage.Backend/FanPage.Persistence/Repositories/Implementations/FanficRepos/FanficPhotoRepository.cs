using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Entities.Fanfic;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces.IFanfic;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Persistence.Repositories.Implementations.FanficRepos
{
    public class FanficPhotoRepository : RepositoryBase<FanficPhoto>, IFanficPhotoRepository
    {
        private readonly FanficContext _context;
        private readonly IMapper _mapper;

        public FanficPhotoRepository(IMapper mapper, FanficContext context) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task CreateAsync(FanficPhotoDto fanficPhoto)
        {
            var fanficPhotoEntity = _mapper.Map<FanficPhoto>(fanficPhoto);
            _context.FanficPhotos.Add(fanficPhotoEntity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            var fanficPhoto = _context.FanficPhotos.FirstOrDefault(x => x.Id == id);
            _context.FanficPhotos.Remove(fanficPhoto);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(FanficPhotoDto fanficPhoto)
        {
            var fanficPhotoEntity = _mapper.Map<FanficPhoto>(fanficPhoto);
            _context.FanficPhotos.Update(fanficPhotoEntity);
            return _context.SaveChangesAsync();
        }
        
        public Task<FanficPhotoDto?> GetByIdAsync(int id)
        {
            return _context.FanficPhotos.Where(w => w.FanficId == id).Select(s => new FanficPhotoDto
            {
                FanficId = s.FanficId,
                Image = s.Image
            }).FirstOrDefaultAsync();
        }
    }
}
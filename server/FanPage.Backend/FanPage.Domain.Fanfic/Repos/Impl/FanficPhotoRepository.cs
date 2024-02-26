using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Context;
using FanPage.Domain.Fanfic.Entities;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Fanfic.Repos.Impl
{
    public class FanficPhotoRepository : RepositoryBase<FanficPhoto>, IFanficPhotoRepository
    {
        private readonly FanficContext _context;
        private readonly IMapper _mapper;

        public FanficPhotoRepository(IMapper mapper, FanficContext context)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(FanficPhotoDto fanficPhoto)
        {
            var fanficPhotoEntity = _mapper.Map<FanficPhoto>(fanficPhoto);
            await _context.FanficPhotos.AddAsync(fanficPhotoEntity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            var fanficPhoto = _context.FanficPhotos.FirstOrDefault(x => x.Id == id);
            _context.FanficPhotos.Remove(fanficPhoto);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FanficPhotoDto fanficPhoto)
        {
            var existingFanficPhotoEntity = await _context.FanficPhotos.FirstOrDefaultAsync(fp =>
                fp.FanficId == fanficPhoto.FanficId
            );

            if (existingFanficPhotoEntity != null)
            {
                existingFanficPhotoEntity.Image = fanficPhoto.Image;
                await _context.SaveChangesAsync();
            }
        }

        public Task<FanficPhotoDto?> GetByIdAsync(int id)
        {
            return _context
                .FanficPhotos.Where(w => w.FanficId == id)
                .Select(s => new FanficPhotoDto { FanficId = s.FanficId, Image = s.Image })
                .FirstOrDefaultAsync();
        }
    }
}

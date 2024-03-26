using AutoMapper;
using FanPage.Application.Photo;
using FanPage.Domain.Account.Context;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;

namespace FanPage.Domain.Account.Repos.Impl
{
    public class UserPhotoRepository : IUserPhotoRepository
    {
        private readonly UserContext _context;
        private readonly IMapper _mapper;

        public UserPhotoRepository(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task CreateAsync(PhotoDto createPhoto)
        {
            var photoMap = _mapper.Map<Photo>(createPhoto);
            _context.Photos.Add(photoMap);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            var photo = _context.Photos.FirstOrDefault(x => x.Id == id);
            _context.Photos.Remove(photo);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(int id, PhotoDto updatePhoto)
        {
            var photo = _context.Photos.FirstOrDefault(x => x.Id == id);
            photo.Image = updatePhoto.Image;
            return _context.SaveChangesAsync();
        }
    }
}

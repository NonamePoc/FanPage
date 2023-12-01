using FanPage.Application.Photo;

namespace FanPage.Persistence.Repositories.Interfaces.IIdentity
{
    public interface IUserPhotoRepository
    {
        Task CreateAsync(PhotoDto createPhoto);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, PhotoDto updatePhoto);
    }
}
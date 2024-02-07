using FanPage.Application.Photo;

namespace FanPage.Domain.Account.Repos.Interfaces
{
    public interface IUserPhotoRepository
    {
        Task CreateAsync(PhotoDto createPhoto);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, PhotoDto updatePhoto);
    }
}
using FanPage.Application.Photo;

namespace FanPage.Infrastructure.Interfaces
{
    public interface IPhoto
    {
        Task Create(PhotoDto createPhoto);

        Task Delete(int id);

        Task Update(int id, PhotoDto updatePhoto);
    }
}
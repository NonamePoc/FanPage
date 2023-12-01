using FanPage.Application.Fanfic;

namespace FanPage.Persistence.Repositories.Interfaces.IFanfic
{
    public interface IFanficPhotoRepository
    {
        Task CreateAsync(FanficPhotoDto fanficPhoto);
        Task DeleteAsync(int id);
        Task UpdateAsync(FanficPhotoDto fanficPhoto);
        
        Task<FanficPhotoDto?> GetByIdAsync(int id);
    }
}
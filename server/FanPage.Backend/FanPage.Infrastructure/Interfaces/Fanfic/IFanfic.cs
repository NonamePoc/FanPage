using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Fanfic
{
    public interface IFanfic
    {
        Task<FanficDto> CreateAsync(CreateDto createFanfic, HttpRequest request);

        Task<FanficDto> UpdateAsync(int fanficId, UpdateDto updateFanfic, HttpRequest request);

        Task DeleteAsync(int id, HttpRequest request);
        
    }
}
using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Fanfic;

public interface IFanficDetail
{
    Task<double> GetAverageRatingAsync(int fanficId);
    Task<List<FanficDto>> SearchAsync(string searchString, bool original);

    Task<List<FanficDto>> GetAllAsync(int count);

    Task<List<FanficDto>> GetByAuthorNameAsync(string name, int count);

    Task<List<FanficDto>> GetLastCreationDateFanficsAsync(int count, HttpRequest request);

    Task<List<FanficDto>> GetTopRatingFanficsAsync(int count, HttpRequest request);

    Task<FanficDto> GetByIdAsync(int id);

    Task ChangeAvatar(int id, IFormFile file, HttpRequest request);

}
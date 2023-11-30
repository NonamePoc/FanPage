using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Fanfic;

public interface IFanficDetail
{
    Task<double> GetAverageRatingAsync(int fanficId);
    Task<List<FanficDto>> SearchAsync(string searchString, HttpRequest request);

    Task<List<FanficDto>> GetAllAsync();

    Task<List<FanficDto>> GetByAuthorNameAsync(string name);

    Task<FanficDto> GetByIdAsync(int id);
}
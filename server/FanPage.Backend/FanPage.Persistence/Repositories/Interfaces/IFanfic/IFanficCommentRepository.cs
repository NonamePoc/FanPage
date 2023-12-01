using FanPage.Domain.Entities.Fanfic;

namespace FanPage.Persistence.Repositories.Interfaces.IFanfic
{
    public interface IFanficCommentRepository
    {
        Task CreateAsync(CommentPhoto fanficComment);
        Task DeleteAsync(int id);
        Task UpdateAsync(CommentPhoto fanficComment);
    }
}
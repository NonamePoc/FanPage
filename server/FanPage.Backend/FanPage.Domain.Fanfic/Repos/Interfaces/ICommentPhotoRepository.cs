using FanPage.Application.Fanfic;

namespace FanPage.Domain.Fanfic.Repos.Interfaces
{
    public interface ICommentPhotoRepository
    {
        Task CreateAsync(CommentPhotoDto fanficComment);
        Task DeleteAsync(int id);
        Task UpdateAsync(CommentPhotoDto fanficComment);
    }
}
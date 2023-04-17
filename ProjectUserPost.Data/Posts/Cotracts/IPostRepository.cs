using ProjectUserPost.Data.Posts.Cotracts.Dtos;
using ProjectUserPost.Entities;

namespace ProjectUserPost.Data.Posts.Cotracts
{
    public interface IPostRepository
    {
        Task Add(Post post, CancellationToken cancellationToken);

        Task<List<GetAllPostDto>> GetAll();

        Task<Post?> GetById(int id, CancellationToken cancellationToken);

        Task Edit (Post post, CancellationToken cancellationToken);
    }
}

using ProjectUserPost.Data.Posts.Cotracts.Dtos;

namespace ProjectUserPost.Data.Posts.Cotracts
{
    public interface IPostService
    {
        Task<int> Add(AddPostDto dto, CancellationToken cancellationToken);

        Task<List<GetAllPostDto>> GetAll();

        Task<PostGetById> GetById(int id, CancellationToken cancellationToken);

        Task<int> Edit(int id, EditPostDto dto, CancellationToken cancellationToken);
    }
}

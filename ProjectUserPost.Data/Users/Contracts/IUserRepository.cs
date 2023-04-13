using ProjectUserPost.Data.Users.Contracts.Dtos;
using ProjectUserPost.Entities;

namespace ProjectUserPost.Data.Users.Contracts
{
    public interface IUserRepository
    {
        Task Add(User user, CancellationToken cancellationToken);

        Task<bool> IsExistUserById(int id, CancellationToken cancellationToken);

        Task<List<GetAllUserDto>> GetAll();

        Task<List<GetForAddPost>> GetUsersForAddPost();

        Task<User?> GetById(int id, CancellationToken cancellationToken);
    }
}

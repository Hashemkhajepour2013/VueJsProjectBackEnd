using ProjectUserPost.Data.Repositories.Contracts;
using ProjectUserPost.Data.Users.Contracts.Dtos;
using ProjectUserPost.Entities;

namespace ProjectUserPost.Data.Users.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsExistUserById(int id, CancellationToken cancellationToken);

        Task<List<GetAllUserDto>> GetAll(CancellationToken cancellationToken);

        Task<List<GetForAddPost>> GetUsersForAddPost(CancellationToken cancellationToken);
    }
}

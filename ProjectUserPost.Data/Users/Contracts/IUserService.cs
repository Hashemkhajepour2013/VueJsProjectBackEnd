using ProjectUserPost.Data.Users.Contracts.Dtos;

namespace ProjectUserPost.Data.Users.Contracts
{
    public interface IUserService
    {
        Task<int> Add(AddUserDto dto, CancellationToken cancellationToken);

        Task<List<GetForAddPost>> GetUsersForAddPost(CancellationToken cancellationToken);

        Task<List<GetAllUserDto>> GetAll(CancellationToken cancellationToken);

        Task<UserGetByIdDto> GetById(int id, CancellationToken cancellationToken);

        Task Edit(int id, EditUserDto dto, CancellationToken cancellationToken);

        Task ChangeActive(int id, CancellationToken cancellationToken);

        Task Delete(int id, CancellationToken cancellationToken);
    }
}

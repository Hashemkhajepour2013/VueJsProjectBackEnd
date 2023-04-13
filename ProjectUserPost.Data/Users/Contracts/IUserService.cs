using ProjectUserPost.Data.Users.Contracts.Dtos;

namespace ProjectUserPost.Data.Users.Contracts
{
    public interface IUserService
    {
        Task<int> Add(AddUserDto dto, CancellationToken cancellationToken);

        Task<List<GetForAddPost>> GetUsersForAddPost();

        Task<List<GetAllUserDto>> GetAll();

        Task<UserGetByIdDto> GetById(int id, CancellationToken cancellationToken);
    }
}

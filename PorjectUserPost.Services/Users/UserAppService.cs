using ProjectUserPost.Data.Users.Contracts;
using ProjectUserPost.Data.Users.Contracts.Dtos;
using ProjectUserPost.Entities;

namespace PorjectUserPost.Services.Users
{
    public sealed class UserAppService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserAppService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(AddUserDto dto, CancellationToken cancellationToken)
        {
            User user = PrototypingOfUser(dto);

            await _repository.Add(user, cancellationToken);

            return user.Id;
        }

        public Task<List<GetAllUserDto>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<List<GetForAddPost>> GetUsersForAddPost()
        {
            return _repository.GetUsersForAddPost();

        }

        public async Task<UserGetByIdDto> GetById(int id, CancellationToken cancellationToken)
        {
            User? user = await StopIfUserNotFound(id, cancellationToken);
            return new UserGetByIdDto
            {
                Company = user.Company,
                Email = user.Email,
                Name = user.Name,
                Phone = user.Phone,
                UserName = user.UserName,
                Website = user.Website
            };
        }

        private async Task<User?> StopIfUserNotFound(int id, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(id, cancellationToken);
            if (user == null)
            {
                throw new Exception("کاربر یافت نشد");
            }

            return user;
        }

        private static User PrototypingOfUser(AddUserDto dto)
        {
            return new User
            {
                Company = dto.Company,
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone,
                UserName = dto.UserName,
                Website = dto.Website
            };
        }
    }
}

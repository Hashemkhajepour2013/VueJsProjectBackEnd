using AutoMapper;
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
            var user = Mapper.Map<User>(dto);
            
            await _repository.AddAsync(user, cancellationToken);

            return user.Id;
        }

        public Task<List<GetAllUserDto>> GetAll(CancellationToken cancellationToken)
        {
            return _repository.GetAll(cancellationToken);
        }

        public Task<List<GetForAddPost>> GetUsersForAddPost(CancellationToken cancellationToken)
        {
            return _repository.GetUsersForAddPost(cancellationToken);
        }

        public async Task<UserGetByIdDto> GetById(int id, CancellationToken cancellationToken)
        {
            User? user = await StopIfUserNotFound(id, cancellationToken);
            return Mapper.Map<UserGetByIdDto>(user);
        }

        public async Task Edit(int id, EditUserDto dto, CancellationToken cancellationToken)
        {
            var user = await StopIfUserNotFound(id, cancellationToken);

            Mapper.Map(dto, user);

            await _repository.UpdateAsync(user, cancellationToken);
        }

        public async Task ChangeActive(int id, CancellationToken cancellationToken)
        {
            var user = await StopIfUserNotFound(id, cancellationToken);
            user.IsActive = !user.IsActive;

            await _repository.UpdateAsync(user, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var user = await StopIfUserNotFound(id, cancellationToken); 

            await _repository.DeleteAsync(user, cancellationToken);
        }

        private async Task<User?> StopIfUserNotFound(int id, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(cancellationToken, id);
            if (user == null)
            {
                throw new Exception("کاربر یافت نشد");
            }

            return user;
        }
    }
}
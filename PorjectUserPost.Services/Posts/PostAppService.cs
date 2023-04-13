using ProjectUserPost.Data.Posts.Cotracts;
using ProjectUserPost.Data.Posts.Cotracts.Dtos;
using ProjectUserPost.Data.Users.Contracts;
using ProjectUserPost.Data.Users.Contracts.Dtos;
using ProjectUserPost.Entities;

namespace PorjectUserPost.Services.Posts
{
    public sealed class PostAppService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly IUserRepository _userRepository;
        public PostAppService(
            IPostRepository repository,
            IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<int> Add(AddPostDto dto, CancellationToken cancellationToken)
        {
            await StopIfUserNotFound(dto, cancellationToken);

            Post post = PrototypingOfPost(dto);

            await _repository.Add(post, cancellationToken);

            return post.Id;
        }

        public Task<List<GetAllPostDto>> GetAll()
        {
            return _repository.GetAll();
        }

        private async Task StopIfUserNotFound(AddPostDto dto, CancellationToken cancellationToken)
        {
            var user = await _userRepository.IsExistUserById(dto.userId, cancellationToken);
            if (!user)
            {
                throw new Exception("کاربری یافت نشد");
            }
        }

        private static Post PrototypingOfPost(AddPostDto dto)
        {
            return new Post
            {
                Title = dto.Title,
                Body = dto.Body,
                userId = dto.userId
            };
        }

        public async Task<PostGetById> GetById(int id, CancellationToken cancellationToken)
        {
            var post = await _repository.GetById(id, cancellationToken);

            return new PostGetById
            {
                Body = post.Body,
                NameUser = post.User.Name,
                Title = post.Title
            };
        }
    }
}

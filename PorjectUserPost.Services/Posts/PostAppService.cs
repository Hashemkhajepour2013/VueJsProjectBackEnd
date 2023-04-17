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
            await StopIfUserNotFound(dto.userId, cancellationToken);

            Post post = PrototypingOfPost(dto);

            await _repository.Add(post, cancellationToken);

            return post.Id;
        }

        public Task<List<GetAllPostDto>> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<int> Edit(int id, EditPostDto dto, CancellationToken cancellationToken)
        {
            await StopIfUserNotFound(dto.userId, cancellationToken);

            Post? post = await StopIfPostNotFound(id, cancellationToken);

            post.Title = dto.Title;
            post.Body = dto.Body;
            post.userId = dto.userId;

            await _repository.Edit(post, cancellationToken);

            return post.Id;
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

        private async Task StopIfUserNotFound(int userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.IsExistUserById(userId, cancellationToken);
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

        private async Task<Post?> StopIfPostNotFound(int id, CancellationToken cancellationToken)
        {
            var post = await _repository.GetById(id, cancellationToken);
            if (post == null)
            {
                throw new Exception("پست مورد نظر یافت نشد");
            }

            return post;
        }
    }
}

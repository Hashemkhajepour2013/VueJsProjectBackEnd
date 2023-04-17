using Microsoft.EntityFrameworkCore;
using ProjectUserPost.Data.Posts.Cotracts;
using ProjectUserPost.Data.Posts.Cotracts.Dtos;
using ProjectUserPost.Entities;

namespace ProjectUserPost.Data.Posts
{
    public class EFPostRepository : IPostRepository
    {
        private ApplicationDbContext _context;
        public EFPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post, CancellationToken cancellationToken)
        {
            await _context.AddAsync(post, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Edit(Post post, CancellationToken cancellationToken)
        {
            _context.Set<Post>().Update(post);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<GetAllPostDto>> GetAll()
        {
            return await _context.Set<Post>().Select(_ => new GetAllPostDto
            {
                Body = _.Body,
                Title = _.Title,
                Id = _.Id,
                NameUser = _.User.Name
            }).ToListAsync();
        }

        public Task<Post?> GetById(int id, CancellationToken cancellationToken)
        {
            return _context.Set<Post>().Include(_ => _.User).FirstOrDefaultAsync(_ => _.Id == id ,cancellationToken);
        }
    }
}

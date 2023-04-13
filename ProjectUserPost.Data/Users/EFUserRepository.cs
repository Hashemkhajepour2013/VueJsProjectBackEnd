using Microsoft.EntityFrameworkCore;
using ProjectUserPost.Data.Users.Contracts;
using ProjectUserPost.Data.Users.Contracts.Dtos;
using ProjectUserPost.Entities;

namespace ProjectUserPost.Data.Users
{
    public sealed class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext _context;
        public EFUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user, CancellationToken cancellationToken)
        {
            await _context.AddAsync(user, cancellationToken);

            await _context.SaveChangesAsync();
        }

        public async Task<List<GetAllUserDto>> GetAll()
        {
            return await _context.Set<User>().Select(_ => new GetAllUserDto
            {
                Id = _.Id,
                Company = _.Company,
                Phone = _.Phone,
                Email = _.Email,
                Name = _.Name,
                UserName = _.UserName,
                Website = _.Website
            }).ToListAsync();
        }

        public async Task<User?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
        }

        public async Task<List<GetForAddPost>> GetUsersForAddPost()
        {
            return await _context.Set<User>().Select(_ => new GetForAddPost
            {
                Id = _.Id,
                Name = _.Name,
            }).ToListAsync();
        }

        public async Task<bool> IsExistUserById(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<User>().AnyAsync(_ => _.Id == id, cancellationToken);
        }
    }
}

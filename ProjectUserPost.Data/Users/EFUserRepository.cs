using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjectUserPost.Common;
using ProjectUserPost.Data.Repositories;
using ProjectUserPost.Data.Users.Contracts;
using ProjectUserPost.Data.Users.Contracts.Dtos;
using ProjectUserPost.Entities;

namespace ProjectUserPost.Data.Users
{
    public sealed class EFUserRepository : Repository<User>, IUserRepository,IScopedDependency
    {
        public EFUserRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<List<GetAllUserDto>> GetAll(CancellationToken cancellationToken)
        {
            return await TableNoTracking.ProjectTo<GetAllUserDto>().ToListAsync(cancellationToken);
        }
        
        public async Task<List<GetForAddPost>> GetUsersForAddPost(CancellationToken cancellationToken)
        {
            return await TableNoTracking.ProjectTo<GetForAddPost>().ToListAsync(cancellationToken);
        }

        public async Task<bool> IsExistUserById(int id, CancellationToken cancellationToken)
        {
            return await TableNoTracking.AnyAsync(_ => _.Id == id, cancellationToken);
        }
    }
}

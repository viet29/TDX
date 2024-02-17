using API.Data;
using API.Entities;
using API.Entities.Responses;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<UserResponse> GetMemberByUsernameAsync(string userName)
        {
            return await context.Users.Where(x => x.UserName == userName).ProjectTo<UserResponse>(mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserResponse>> GetMembersAsync()
        {
            return await context.Users.ProjectTo<UserResponse>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await context.Users
                .Include(p => p.AvatarImg)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await context.Users
                .Include(p => p.AvatarImg)
                .ToListAsync();
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}

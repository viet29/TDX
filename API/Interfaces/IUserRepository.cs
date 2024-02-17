using API.Entities;
using API.Entities.Responses;
using API.Helpers;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(User user);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> GetUserByUsernameAsync(string username);
        //Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        //Task<MemberDto> GetMemberAsync(string username);
        //Task<string> GetUserGender(string username);

        Task<IEnumerable<UserResponse>> GetMembersAsync();

        Task<UserResponse> GetMemberByUsernameAsync(string username);

        Task<bool> SaveAllAsync();
    }
}

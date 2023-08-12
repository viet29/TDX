﻿using API.DTO;
using API.Entities;
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

        Task<IEnumerable<MemberDTO>> GetMembersAsync();

        Task<MemberDTO> GetMemberByUsernameAsync(string username);
    }
}

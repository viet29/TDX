namespace API.Entities.Responses
{
    public class UserResponse
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public DateOnly DOB { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public string Province { get; set; }
        public string School { get; set; }
        public string Description { get; set; }
    }
}

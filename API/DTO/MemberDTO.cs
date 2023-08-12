namespace API.DTO
{
    public class MemberDTO
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public DateOnly DOB { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}

namespace API.DTO
{
    public class UserUpdateDTO
    {
        public string Description { get; set; }
        public string FullName { get; set; }
        public DateOnly DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        public string Province { get; set; }
        public string School { get; set; }
    }
}

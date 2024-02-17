namespace API.Entities.Requests
{
    public class FaqRequest
    {
        public int Id { get; set; }

        public String Question { get; set; }

        public String Answer { get; set; }

        public User User { get; set; }
    }
}

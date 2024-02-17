namespace API.Entities.Responses
{
    public class FaqResponse
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public User User { get; set; }
    }
}

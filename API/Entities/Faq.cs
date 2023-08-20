namespace API.Entities
{
    public class Faq
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public User User { get; set; }
    }
}

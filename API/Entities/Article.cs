namespace API.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsPublished { get; set; }   
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set;}

        public string AdminId { get; set; }
        public Admin Admin { get; set; }

    }
}

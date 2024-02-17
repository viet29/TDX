namespace API.Entities.Responses
{
    public class ArticleResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsPublished { get; set; }
    }
}

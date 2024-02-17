namespace API.Entities.Responses
{
    public class ArticleDetailResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

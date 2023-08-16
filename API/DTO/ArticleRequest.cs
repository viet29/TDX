using API.Entities;

namespace API.DTO
{
    public class ArticleRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; }
    }
}

using API.Entities;

namespace API.Entities.Requests
{
    public class ArticleRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public User User { get; set; }
    }
}

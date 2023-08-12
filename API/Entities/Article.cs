using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Article")]
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsPublished { get; set; }   

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set;}

        public int UserId { get; set; }
        public User User { get; set; }

    }
}

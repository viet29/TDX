using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photo")]
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string PublicId { get; set; }
    }
}
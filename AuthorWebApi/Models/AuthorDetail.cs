using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorWebApi.Models
{
    public class AuthorDetail
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Author? Author { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }
}

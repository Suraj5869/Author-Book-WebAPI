using AuthorWebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorWebApi.DTOs
{
    public class AuthorDetailDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int AuthorId { get; set; }
        
    }
}

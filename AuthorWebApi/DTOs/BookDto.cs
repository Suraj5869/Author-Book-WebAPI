using AuthorWebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorWebApi.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateOnly PublishedDate { get; set; }
        public int AuthorId { get; set; }
    }
}

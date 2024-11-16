using AuthorWebApi.DTOs;
using AuthorWebApi.Models;

namespace AuthorWebApi.Services
{
    public interface IBookService
    {
        public List<BookDto> GetBooks();
        public BookDto GetById(int id);
        public int AddBook(BookDto bookDto);
        public bool DeleteBook(int id);
        public bool UpdateBook(BookDto bookDto);
        public List<BookDto> GetAuthorBooks(int id);
    }
}

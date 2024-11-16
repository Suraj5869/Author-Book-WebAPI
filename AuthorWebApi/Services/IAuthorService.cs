using AuthorWebApi.DTOs;
using AuthorWebApi.Models;

namespace AuthorWebApi.Services
{
    public interface IAuthorService
    {
        public List<AuthorDto> GetAuthors();
        public AuthorDto GetById(int id);
        public int AddAuthor(AuthorDto authorDto);
        public bool DeleteAuthor(int id);
        public bool UpdateAuthor(AuthorDto authorSto);

        public AuthorDto GetByName(string name);
        public AuthorDto GetBookAuthor(int id);
    }
}

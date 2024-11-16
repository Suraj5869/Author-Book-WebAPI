using AuthorWebApi.DTOs;
using AuthorWebApi.Models;

namespace AuthorWebApi.Services
{
    public interface IAuthorDetailsService
    {
        public List<AuthorDetailDto> GetAuthorDetails();
        public AuthorDetailDto GetById(int id);
        public int AddAuthorDetails(AuthorDetailDto authorDetailDto);
        public bool DeleteAuthorDetails(int id);
        public bool UpdateAuthorDetails(AuthorDetailDto authorDetailDto);

        public AuthorDetailDto GetByAuthorId(int authorId);
    }
}

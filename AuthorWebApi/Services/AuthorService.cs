using AuthorWebApi.DTOs;
using AuthorWebApi.Exceptions;
using AuthorWebApi.Models;
using AuthorWebApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> authorRepository, IRepository<Book> repository, IMapper mapper)
        {
            _repository = authorRepository;   
            _bookRepository = repository;
            _mapper = mapper;
        }
        //Add author in database
        public int AddAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _repository.Add(author);
            return author.Id;
        }

        //Delete author from database
        public bool DeleteAuthor(int id)
        {
            var author = _repository.Get(id);
            if (author == null)
            {
                throw new AuthorNotFoundException("Author not found!!");
            }
            _repository.Delete(author);
            return true;
        }

        //Get all available authors from database
        public List<AuthorDto> GetAuthors()
        {
            var authors = _repository.GetAll().Include(a => a.Books).Include(a=>a.AuthorDetail).ToList();
            List<AuthorDto> result = _mapper.Map<List<AuthorDto>>(authors);
            return result;
        }

        //Get author of a particular book using book id
        public AuthorDto GetBookAuthor(int id)
        {
            var books = _bookRepository.GetAll().Include(a => a.Author);
            var book = books.Where(a=> a.Id == id).FirstOrDefault();
            var authorDto = _mapper.Map<AuthorDto>(book);
            return authorDto;
        }

        //Get author by its id
        public AuthorDto GetById(int id)
        {
            var author = _repository.Get(id);
            if (author == null)
                throw new AuthorNotFoundException("No such author found!");
            AuthorDto authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }

        //Get author by its name
        public AuthorDto GetByName(string Name)
        {
            var authors = GetAuthors();
            var authorDto = authors.FirstOrDefault(a=>a.Name == Name);
            if (authorDto == null)
                throw new AuthorNotFoundException("No such author found!");
            return authorDto;
        }

        //Update author in database
        public bool UpdateAuthor(AuthorDto authorDto)
        {
            var existingAuthor = _repository.GetAll().AsNoTracking().FirstOrDefault(b => b.Id == authorDto.Id);
            Author author = _mapper.Map<Author>(authorDto);
            if (existingAuthor == null)
            {
                throw new AuthorNotFoundException("No such author found!");
            }
            _repository.Update(author);
            return true;
        }
    }
}

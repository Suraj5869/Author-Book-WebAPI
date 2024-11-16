using AuthorWebApi.DTOs;
using AuthorWebApi.Exceptions;
using AuthorWebApi.Models;
using AuthorWebApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _repository = bookRepository;
            _mapper = mapper;
        }

        //Add book in database
        public int AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _repository.Add(book);
            return book.Id;
        }

        //Delete book from databaseusing its id
        public bool DeleteBook(int id)
        {
            var book = _repository.Get(id);
            if (book == null)
            {
                throw new BookNotFoundException("No such book found");
            }
            _repository.Delete(book);
            return true;
        }

        //Get books of particular author using author id
        public List<BookDto> GetAuthorBooks(int id)
        {
            var authors = _repository.GetAll().Include(a => a.Author).ToList();
            var books = authors.Where(a => a.AuthorId == id);
            List<BookDto> booksDto = _mapper.Map<List<BookDto>>(books);
            return booksDto;
        }

        //Get all books from database
        public List<BookDto> GetBooks()
        {
            var books = _repository.GetAll().Include(b => b.Author).ToList();
            List<BookDto> booksDtos = _mapper.Map<List<BookDto>>(books);
            return booksDtos;
        }

        //Get book by its id
        public BookDto GetById(int id)
        {
            var book = _repository.Get(id);
            if (book == null)
            {
                throw new BookNotFoundException("No such book found");
            }
            BookDto bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }   

        //Update book in database
        public bool UpdateBook(BookDto bookDto)
        {
            var existingBook = _repository.GetAll().AsNoTracking().FirstOrDefault(b=>b.Id== bookDto.Id);
            Book book = _mapper.Map<Book>(bookDto);
            if(existingBook == null)
            {
                throw new BookNotFoundException("No such book found");
            }
            _repository.Update(book);
            return true;
        }
    }
}

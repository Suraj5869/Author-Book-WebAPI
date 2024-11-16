using AuthorWebApi.DTOs;
using AuthorWebApi.Models;
using AuthorWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService bookService)
        {
            _service = bookService;
        }

        //Get all the books available in database
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookDtos = _service.GetBooks();
            return Ok(bookDtos);
        }

        //Get the book from database by its id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bookDto = _service.GetById(id);
            return Ok(bookDto);
        }

        //Get the books of particular author using authorId
        [HttpGet("author/{authorId}")]
        public IActionResult GetBooks(int authorId)
        {
            var authorBooks = _service.GetAuthorBooks(authorId);
            return Ok(authorBooks);
        }

        //Add new book in database
        [HttpPost]
        public IActionResult Add(BookDto bookDto)
        {
            var newBookId = _service.AddBook(bookDto);
            return Ok(newBookId);
        }

        //Update the book available in database
        [HttpPut]
        public IActionResult Update(BookDto bookDto)
        {
            if (_service.UpdateBook(bookDto))
            {
                return Ok(bookDto);
            }
            return NotFound("No such book found");
        }

        //Delete the book from database using book id 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.DeleteBook(id))
            {
                return Ok(id);
            }
            return NotFound("No such book found");
        }

    }
}

using AuthorWebApi.DTOs;
using AuthorWebApi.Models;
using AuthorWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _services;
        public AuthorController(IAuthorService authorService)
        {
            _services = authorService;
        }

        //Get all authors available in database
        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDtos = _services.GetAuthors();
            return Ok(authorDtos);
        }

        //Get author from daatabase by its name
        [HttpGet("author/{name}")]
        public IActionResult Get(string name)
        {
            var authorDto = _services.GetByName(name);
            return Ok(authorDto);
        }

        //Get author from database by its id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var authorDto = _services.GetById(id);
            return Ok(authorDto);
        }

        //Get author from database by book Id
        //or
        //Get the author of particular book
        [HttpGet("book/{bookId}")]
        public IActionResult GetAuthor(int bookId)
        {
            var book = _services.GetBookAuthor(bookId);
            return Ok(book);
        }

        //Add new author in database
        [HttpPost]
        public IActionResult Add(AuthorDto authorDto)
        {
            var newAuthorId = _services.AddAuthor(authorDto);
            return Ok(newAuthorId);
        }

        //Update the author data in database
        [HttpPut]
        public IActionResult Update(AuthorDto authorDto)
        {
            if (_services.UpdateAuthor(authorDto))
            {
                return Ok(authorDto);
            }
            return NotFound("No such author found");
        }

        //Delete the author data from database
        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            if (_services.DeleteAuthor(id))
            {
                return Ok("Author deleted successfully");
            }
            return NotFound("No such author found");
        }
    }
}

using AuthorWebApi.DTOs;
using AuthorWebApi.Models;
using AuthorWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailController : ControllerBase
    {
        private readonly IAuthorDetailsService _service;

        public AuthorDetailController(IAuthorDetailsService authorDetailsService)
        {
            _service = authorDetailsService;
        }

        //Get all authordetails available in database
        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDetailsDtos = _service.GetAuthorDetails();
            return Ok(authorDetailsDtos);
        }

        //Get the author details from database using id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var authorDetailDto = _service.GetById(id);
            return Ok(authorDetailDto);
        }

        //Add author details in database linked to particular author using authorId as foreign key
        [HttpPost]
        public IActionResult Add(AuthorDetailDto detailDto)
        {
            var newDetailId = _service.AddAuthorDetails(detailDto);
            return Ok(newDetailId);
        }

        //Update author details available in database
        [HttpPut]
        public IActionResult Update(AuthorDetailDto detailDto)
        {
            if (_service.UpdateAuthorDetails(detailDto))
            {
                return Ok(detailDto);
            }
            return NotFound("No such author detail found");
        }

        //Delete the author details from database using author details id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.DeleteAuthorDetails(id))
            {
                return Ok(id);
            }
            return NotFound("No such auhor detail found");
        }

        //Get the authod details from database using author id
        [HttpGet("author/{authorId}")]
        public IActionResult GetByAuthorId(int authorId)
        {
            var authorDetail = _service.GetByAuthorId(authorId);
            return Ok(authorDetail);
        }


    }
}

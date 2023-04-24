using Data.Service.BooksService;
using Data.Service.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _context;

        public AuthorController(IAuthorService context)
        {
            _context = context;
        }

        [HttpPost("addauthor")]
        public async Task<IActionResult> AddAuthor([FromBody]Author author)
        {
            await _context.AddAuthor(author);

            return CreatedAtAction(nameof(GetAuthorById), new {id = author.Id}, author);
        }

        [HttpGet("getauthor/{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            var author = await _context.GetAuthorById(id);

            return Ok(author);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authorList = await _context.GetAllAuthors();

            return Ok(authorList);
        }

        [HttpPatch("update-author/{id}")]
        public async Task<IActionResult> UpdateAuthor(Author newAuthor, Guid id)
        {
            await _context.UpdateAuthor(newAuthor, id);

            return Ok(newAuthor);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> RemoveAuthor(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            await _context.DeleteAuthor(id);

            return NoContent();
        }

    }
}

using Data.Service.BooksService;
using Data.Service.Interfaces;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _context;

        public BookController(IBookService context)
        {
            _context = context;
        }

        [HttpPost("addbook")]
        public async Task<IActionResult> AddBook([FromBody]Book book)
        {
            await _context.AddBook(book);

            return CreatedAtAction(nameof(GetBookById), new {id = book.Id},  book);
        }

        [HttpGet("getbook/{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = _context.GetBookById(id);

            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var bookList = await _context.GetAllBooks();

            return Ok(bookList);
        }

        [HttpPatch("updatebook/{id}")]
        public async Task<IActionResult> UpdateBook(Book newBook, Guid id)
        {
            await _context.UpdateBook(newBook, id);

            return Ok(newBook);
        }

        [HttpPost("addAuthorToBook/{bookId}/{authorId}")]
        public async Task<IActionResult> AddAuthorToBook(Guid bookId, Guid authorId)
        {
            await _context.AddAuthorToBook(bookId, authorId);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> RemoveBook(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            await _context.DeleteBook(id);

            return Ok();
        }

    }
}

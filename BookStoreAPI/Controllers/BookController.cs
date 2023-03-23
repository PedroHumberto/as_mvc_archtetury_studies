using Data.Service.BooksService;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _context;

        public BookController(IBookService context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddBook([FromBody]Book book)
        {
            _context.AddBook(book);

            return CreatedAtAction(nameof(GetBookById), new {id = book.Id},  book);
        }
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = _context.GetBookById(id);

            return Ok(book);
        }
    }
}

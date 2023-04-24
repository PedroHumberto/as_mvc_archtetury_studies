using Data.Service.Interfaces;
using Domain.Dto.BookDto;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    [Authorize]
    public class BookStoreController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookStoreController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region(BookActions)
        public async Task<IActionResult> Books()
        {
            var bookList = await _bookService.GetAllBooks();
            return View(bookList);
        }

        public async Task<IActionResult> CheckBook(Guid id)
        {
            var bookAuthor = await _bookService.GetBookAuthorById(id);

            return View(bookAuthor);
        }

        //FORM CREATE BOOK
        public async Task<IActionResult> BookForm()
        {
            var authors = await _authorService.GetAllAuthors();

            if (authors == null)
            {
                authors = new List<Author>();
            }

            ViewBag.Author = new SelectList(authors, "Id", "FirstName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookForm(CreateBookDto creatDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bookParse = new Book()
                    {
                        Id = creatDto.Id,
                        BookAuthor = creatDto.BookAuthor,
                        ISBN = creatDto.ISBN,
                        Title = creatDto.Title,
                        Year = creatDto.Year
                    };

                    await _bookService.AddBook(bookParse);
                    await _bookService.AddAuthorToBook(bookParse.Id, creatDto.AuthorId);

                    return RedirectToAction(nameof(Books));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }

            return View(creatDto);
        }

        //DELETE
        public async Task<IActionResult> DeleteBookForm(Guid id)
        {
            if (ModelState.IsValid)
            {
                var book = await _bookService.GetBookById(id);

                return View(book);
            }
            return View(id);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBook(Guid id)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.DeleteBook(id);

                    return RedirectToAction(nameof(Books));
                }
                catch (Exception ex)
                {
                    Console.Write("ERRO " + ex.ToString());

                    return BadRequest(ex.ToString());
                }

            }
            return View(id);
        }

        //UPDATE
        public async Task<IActionResult> UpdateBook(Guid id)
        {
           
            if (ModelState.IsValid)
            {
                var book = await _bookService.GetBookById(id);

                return View(book);
            }
            return View(id);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book updatedBook, Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.UpdateBook(updatedBook, id);

                    return RedirectToAction(nameof(Books));
                }
                catch (Exception ex)
                {
                    Console.Write("ERRO " + ex.ToString());

                    return BadRequest(ex.ToString());
                }

            }
            return View(updatedBook);
        }


        #endregion


        #region(AuthorActions)

        public async Task<IActionResult> Authors()
        {
            var authorList = await _authorService.GetAllAuthors();
            return View(authorList);
        }

        public async Task<IActionResult> CheckAuthor(Guid id)
        {
            var bookAuthor = await _authorService.GetBooksFromAuthor(id);

            return View(bookAuthor);
        }


        //FORM CREATE AUTHOR
        public async Task<IActionResult> AuthorForm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AuthorForm(Author creatAuthor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorService.AddAuthor(creatAuthor);

                    return RedirectToAction(nameof(Authors));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            return View(creatAuthor);
        }

        //DELETE
        public async Task<IActionResult> DeleteAuthorForm(Guid id)
        {
            if (ModelState.IsValid)
            {
                var author = await _authorService.GetAuthorById(id);

                return View(author);
            }
            return View(id);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _authorService.DeleteAuthor(id);

                    return RedirectToAction(nameof(Authors));
                }
                catch (Exception ex)
                {
                    Console.Write("ERRO " + ex.ToString());

                    return BadRequest(ex.ToString());
                }

            }
            return View(id);
        }

        //UPDATE
        public async Task<IActionResult> UpdateAuthor(Guid id)
        {

            if (ModelState.IsValid)
            {
                var author = await _authorService.GetAuthorById(id);

                return View(author);
            }
            return View(id);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(Author updatedAuthor, Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorService.UpdateAuthor(updatedAuthor, id);

                    return RedirectToAction(nameof(Authors));
                }
                catch (Exception ex)
                {
                    Console.Write("ERRO " + ex.ToString());

                    return BadRequest(ex.ToString());
                }

            }
            return View(updatedAuthor);
        }

        #endregion


    }
}

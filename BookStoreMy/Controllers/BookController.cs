using BookStoreMy.Models;
using BookStoreMy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreMy.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task <IActionResult> GetAllBooks()
        {
            return View(await _bookRepository.GetAllBooks());
        }
        public async Task<IActionResult> GetBook(int id)
        {
            return View(await _bookRepository.GetBookById(id));
        }
        //public IActionResult SearchBooks(string title, string authorName)
        //{
        //    ToDo;
        //}
        public IActionResult AddNewBook()
        {
            ViewBag.Language = new List<string> { "Hindi", "English", "Georgian"};
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<BookModel>> AddNewBook(BookModel book)
        {
            ViewBag.Language = new List<string> { "Hindi", "English", "Georgian" };
            if (ModelState.IsValid)
            {
                try
                {
                    if (book == null)
                        return BadRequest();

                    var createdBook = await _bookRepository.AddBook(book);

                    return RedirectToAction(nameof(GetAllBooks));
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error creating new employee record");
                }                
            }
            return View();
        }
    }
}

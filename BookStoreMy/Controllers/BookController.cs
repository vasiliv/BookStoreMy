using BookStoreMy.Models;
using BookStoreMy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //Part 55
            //ViewBag.Language = new SelectList(new List<string> { "Hindi", "English", "Georgian" });
            //Part 56 if we take data from hardcoded GetLanguage method
            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            //Part 56 if we take data from db
            //ViewBag.Language = new SelectList(_bookRepository.GetLanguages(), "Id", "Text");
            //Part 57 if we take data from hardcoded GetLanguage method
            //ViewBag.Language = GetLanguages().Select(n => new SelectListItem() 
            //                                    { Value = n.Id.ToString(), Text = n.Text}).ToList();
            //Part 57 if we take data from db
            ViewBag.Language = _bookRepository.GetLanguages().Select(n => new SelectListItem()
                                                  { Value = n.Id.ToString(), Text = n.Text }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<BookModel>> AddNewBook(BookModel book)
        {
            //Part 55
            //ViewBag.Language = new SelectList(new List<string> { "Hindi", "English", "Georgian" });
            //Part 56 if we take data from hardcoded GetLanguage method
            //ViewBag.Language = new SelectList(GetLanguages(), "Id", "Text");
            //Part 56 if we take data from db
            //ViewBag.Language = new SelectList(_bookRepository.GetLanguages(), "Id", "Text");
            //Part 57 if we take data from hardcoded GetLanguage method
            //ViewBag.Language = GetLanguages().Select(n => new SelectListItem()
            //                    { Value = n.Id.ToString(), Text = n.Text }).ToList();
            //Part 57 if we take data from db
            ViewBag.Language = _bookRepository.GetLanguages().Select(n => new SelectListItem()
                                    { Value = n.Id.ToString(), Text = n.Text }).ToList();   
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
        private List<LanguageModel> GetLanguages()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){Id = 1, Text = "Hindi"},
                new LanguageModel(){Id = 2, Text = "English"},
                new LanguageModel(){Id = 3, Text = "Georgian"}
            };
        }
    }
}

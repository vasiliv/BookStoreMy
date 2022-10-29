using BookStoreMy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMy.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult GetAllBooks()
        {
            return View(_bookRepository.GetAllBooks());
        }
        public IActionResult GetBook(int id)
        {
            return View(_bookRepository.GetBookById(id));
        }
        //public IActionResult SearchBooks(string title, string authorName)
        //{
        //    ToDo;
        //}
    }
}

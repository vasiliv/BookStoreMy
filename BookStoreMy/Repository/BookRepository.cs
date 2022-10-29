using BookStoreMy.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMy.Repository
{
    public class BookRepository
    {
        private List<BookModel> DataSource = new List<BookModel>() {
                new BookModel(){ Id = 1, Title = "C#", Author ="Bill"},
                new BookModel(){ Id = 2, Title = "Java",  Author ="Steve"},
                new BookModel(){ Id = 3, Title = "PHP",  Author ="Ram"},
                new BookModel(){ Id = 4, Title = "Python",  Author ="Abdul"}
            };
        public List<BookModel> GetAllBooks()
        {
            return  DataSource;
        }
        public BookModel GetBookById(int id)
        {
            return DataSource.FirstOrDefault(d => d.Id == id);
        }
        //public List<BookModel> SearchBook(string title, string authorName)
        //{
        //    var searchedBook = (from num in DataSource select num).Contains(title);
        //    return DataSource.Contains(title);
        //}
    }
}

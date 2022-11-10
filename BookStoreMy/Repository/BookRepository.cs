using BookStoreMy.Data;
using BookStoreMy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStoreMy.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }        
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
            //webgentlis kkodi arasachiroa
            //var books = new List<BookModel>();
            //var allbooks = await _context.Books.ToListAsync();
            //if (allbooks?.Any() == true)
            //{
            //    foreach (var book in allbooks)
            //    {
            //        books.Add(new BookModel()
            //        {
            //            Author = book.Author,
            //            Category = book.Category,
            //            Description = book.Description,
            //            Id = book.Id,
            //            MultiLanguage = book.MultiLanguage,
            //            Title = book.Title,
            //            TotalPages = book.TotalPages
            //        });
            //    }
            //}
            //return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(d => d.Id == id);
        }
        //public List<BookModel> SearchBook(string title, string authorName)
        //{
        //    var searchedBook = (from num in DataSource select num).Contains(title);
        //    return DataSource.Contains(title);
        //}
        public async Task<BookModel> AddBook(BookModel book)
        {            
            var result = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        //public async Task<List<LanguageModel>> GetLanguage()
        //{
        //    return await _context.Languages.ToListAsync();
        //}
        public List<LanguageModel> GetLanguages()
        {
            return _context.Languages.ToList();
        }
    }
}

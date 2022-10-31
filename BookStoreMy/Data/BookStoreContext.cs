using BookStoreMy.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStoreMy.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        public DbSet<BookModel> Books { get; set; }
    }
}

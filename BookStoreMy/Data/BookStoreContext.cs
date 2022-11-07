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
        public DbSet<LanguageModel> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookModel>().HasData(
                new BookModel {
                    Id = 1,
                    Author = "Vasil",
                    Category = "Programming",
                    Description = "BlaBla",
                    Language = "Georgian",
                    Title = "C#",
                    TotalPages = 400
                },
                new BookModel
                {
                    Id = 2,
                    Author = "Nitish",
                    Category = "It",
                    Description = "BlaBla",
                    Language = "English",
                    Title = "Java",
                    TotalPages = 600
                });
            modelBuilder.Entity<LanguageModel>().HasData(
                new LanguageModel
                {
                    Id = 1,
                    Text = "Hindi"
                },
                new LanguageModel
                {
                    Id = 2,
                    Text = "English"
                },
                new LanguageModel
                {
                    Id = 3,
                    Text = "Georgian"
                });
        }
    }
}

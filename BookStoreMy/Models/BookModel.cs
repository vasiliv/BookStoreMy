using System.ComponentModel.DataAnnotations;

namespace BookStoreMy.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage ="Please enter the title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter the number of pages")]
        [Display(Name = "Total pages of the book")]
        public int? TotalPages { get; set; }
    }
}

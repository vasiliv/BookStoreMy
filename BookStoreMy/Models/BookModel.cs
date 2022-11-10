using BookStoreMy.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required(ErrorMessage = "Please select the language")]
        public string Language { get; set; }
        //if NotMapped attribute not used -
        //InvalidOperationException: The property 'BookModel.MultiLanguage' could not be mapped because it is of type 'List<string>',
        //which is not a supported primitive type or a valid entity type. Either explicitly map this property, or ignore it using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.
        //Part59
        //[NotMapped]
        //public List<string> MultiLanguage { get; set; }
        public LanguageEnum LanguageEnum { get; set; }
        [Required(ErrorMessage = "Please enter the number of pages")]
        [Display(Name = "Total pages of the book")]
        public int? TotalPages { get; set; }
    }
}
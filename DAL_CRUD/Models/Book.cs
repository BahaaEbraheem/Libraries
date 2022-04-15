using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_CRUD.Models
{
    [Table("books"/*, Schema = "dbo"*/)]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Total Pages")]
        public int? TotalPages { get; set; }

        [Display(Name = "Price")]
        public float? Price { get; set; }
        [Display(Name = "Published Date ")]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        [Display(Name = "Language")]
        public string Language { get; set; }
        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;
        // public virtual ICollection<Library_Book> Library_Book { get; set; }

    }
}

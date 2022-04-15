using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_CRUD.Models
{
    [Table("Library"/*, Schema = "dbo"*/)]
    public class Library
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
     
        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }
        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;
        //public virtual ICollection<Library_Book> Library_Book { get; set; }
    }
}

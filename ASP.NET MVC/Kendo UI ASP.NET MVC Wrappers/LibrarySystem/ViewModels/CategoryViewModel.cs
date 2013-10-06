using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.Books = new HashSet<BookViewModel>();
        }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }

    public class BookCategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
    }
}
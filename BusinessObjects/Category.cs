using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class Category : Entity
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(150, ErrorMessage = "Category Name must be between 1 and 150 characters.")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheDeepO.Models
{
    public class CategoryClass
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter a Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter a Subcategory")]
        public string Subcategory { get; set; }
        public string ItemID { get; set; }
        public List<CategoryClass> Subcategoryies { get; set; }
        public List<Choice> Choices { get; set; }
        public CategoryClass Parent { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace RevClothing.Models
{
    public class Product
    {
        [Key]   
        public int ProductID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Required")]

        public virtual Categoryclothes Category { get; set; }
        public int? CategoryID { get; set; }




    }
    public class Categoryclothes
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }

}

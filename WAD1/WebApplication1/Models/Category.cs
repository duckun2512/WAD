using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter an Image")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
    }
}
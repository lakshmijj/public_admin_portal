using System;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace publicAdminPortal.Models {

    public class Category {
        
        // ------------------------------------------------------- get/set methods
        [Key]
        public int categoryId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="Category Name")]
        public string categoryName {get; set;}        

          private DbSet<Category> tblCategory{get;set;}

        // -------------------------------------------------------- public methods
        
    }
}

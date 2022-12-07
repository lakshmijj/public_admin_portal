using System;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace publicAdminPortal.Models {

    public class Link {
        
        // ------------------------------------------------------- get/set methods
        [Key]
        public int linkId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="Link Name")]
        public string link {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="Link")]
        public string href {get; set;}
        public int categoryId {get; set;}
        public int pinned {get; set;}      
        

          private DbSet<Link> tblLink{get;set;}

        // -------------------------------------------------------- public methods
        
    }
}

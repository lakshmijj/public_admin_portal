using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace publicAdminPortal.Models {

    public class Link {
        
        // ------------------------------------------------------- get/set methods
        [Key]
        public int linkId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Maximum 100 characters are allowed")]
        [Display(Name="Label Name")]
        public string link {get; set;}
        [Required]
        [MaxLength(100, ErrorMessage ="Maximum 100 characters are allowed")]
        [Url(ErrorMessage="Please enter a valid Url")]
        [Display(Name="Link")]
        public string href {get; set;}
        public int categoryId {get; set;}
        public string pinned {get; set;}             

        // public DbSet<Link> tblLink{get;set;}

       
         // -------------------------------------------------- get/sets
          

         // -------------------------------------------------------- public methods
        
    }
}

using System;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace publicAdminPortal.Models {

    public class Customer {
        
        // ------------------------------------------------------- get/set methods
        [Key]
        public int customerID { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name="Last Name")]
        public string lastName {get; set;}
        [Required]
        [MaxLength(50)]
        [Display(Name="First Name")]
        public string firstName {get; set;}
        public string address {get; set;}
        public string city {get; set;}
        public string province {get; set;}
        [RegularExpression(@"^[A-Z]\d[A-Z] ?\d[A-Z]\d$", ErrorMessage="Postal should be in format A1A 1A1")]
        public string postal {get; set;}
        [Required]
        [MaxLength(12)]
        [RegularExpression(@"^(\d{3}-)?\d{3}-\d{4}$", ErrorMessage="Phone number should be in format XXX-XXX-XXXX")]
        [Display(Name="Phone Number")]
        public string phone {get; set;}

        

          private DbSet<Customer> tblCustomer{get;set;}

        // -------------------------------------------------------- public methods
        
    }
}

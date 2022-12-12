using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace publicAdminPortal.Models {

    public class CategoryManager: DbContext {

        private DbSet<Category> tblCategory{get;set;}

        // -------------------------------------------------- get/sets
        public List<Category> categories {
            get {
                return tblCategory.ToList();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8,0,11)));
        }     
       

       //public method

       /*
       Fetch Categories as select list to populate dropdown.    
       */
       public SelectList getSelectList(){
            List<Category> listData = tblCategory.OrderBy(c=>c.categoryName).ToList();
            return new SelectList(listData, "categoryId", "categoryName");
        }
    }

}
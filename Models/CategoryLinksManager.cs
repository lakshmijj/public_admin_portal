using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace publicAdminPortal.Models {

    public class category{
         public int categoryId {get;set;}
         public string categoryName {get;set;}

    }

    public class Result{
	public int linkId {get;set;}
	public string link {get;set;}
	public string href {get;set;}
	public int categoryId {get;set;}
	public string pinned {get;set;}
	public string category {get;set;}
}

    public class CategoryLinksManager: DbContext {

        private DbSet<Link> tblLink{get;set;}
         private DbSet<Category> tblCategory{get;set;}

        public int selectedLink = 0;
              
        // -------------------------------------------------- get/sets
        public List<Link> links {
            get {
                return tblLink.ToList();
            }
        }

        public List<Category> categories {
            get {
                return tblCategory.ToList();
            }
        }

        public List<Result> categoryLinks {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8,0,11)));
        }


        //Category dropdown data to be populated from tblCategory
        public SelectList getSelectList(){
            List<Category> listData = tblCategory.OrderBy(c=>c.categoryName).ToList();
            return new SelectList(listData, "categoryId", "categoryName");
        }


        /*
          Function to get category details from tblCategory by categoryId
        */
        public Category getCategoryById(int categoryId){
            Category category  = tblCategory
                    .Where(c => c.categoryId == categoryId)
                    .FirstOrDefault();
              return category;
        }

        /*
          Function to get link details from tblLink by linkId
        */
        public Link getLinkById(int linkId){
            Link link  = tblLink
                    .Where(l => l.linkId == linkId)
                    .FirstOrDefault();
              return link;
        }

        /*
          Function to build the json to populate the main list
          GroupBy - Category

        */
        public void getLinksByCategory(){  
            var categories = tblCategory;         
            var links = tblLink;
            categoryLinks = (from l in links
                    join c in categories on l.categoryId equals c.categoryId 
                    select new Result{
                    linkId = l.linkId,
                    link = l.link,
                    href = l.href,
                    category = c.categoryName,
                    categoryId = l.categoryId,
                    pinned = l.pinned.ToString()
		    }).ToList();

            //Console.WriteLine(">>>>>>>>>>>>> categories: "+ result1.Count);
             
           //Console.WriteLine(JsonSerializer.Serialize(result1));
           //return result1;
        }
       
    }

}
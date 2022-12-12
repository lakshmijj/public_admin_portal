using System;
using publicAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace publicAdminPortal.Controllers {

    public class AdminController : Controller {

        //Landing for the Admin page
        public IActionResult Index() {            

            // Redirect to login if the user is not logged in
            if(HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("index", "Login");
            }

            /*
            * CategoryLinksManager is the model which extracts data from categories and corresponding links
            */
            CategoryLinksManager categoryLinksManager = new CategoryLinksManager();
            categoryLinksManager.getLinksByCategory();

            //ViewData is for setting empty message
            string feedback = "";            
            if(categoryLinksManager.categories.Count == 0){
                ViewData["feedback"] = "There is no data...";
            }
            return View(categoryLinksManager);                    
        }

        //On Logout, clear the session and redirect to Login page
        public IActionResult Logout() {       
            HttpContext.Session.Clear();     
            return RedirectToAction("index", "Login");           
        }

        /*
        * Add Link button click. Prepopulate the categoryId and Category Name
        */
        [HttpPost]
        public IActionResult Add(int categoryId, string categoryName) {
            ViewBag.categoryName = categoryName;
            ViewBag.categoryId = categoryId;
            // construct the Link model
            Link link = new Link();         
            link.categoryId = categoryId;   
            // pass it into the view for populating
            return View(link);
        }

        /*
        * Submit button click. Submit the Link Model
        */
         [HttpPost]
        public IActionResult AddSubmit(Link links) {
            LinkManager linkManager = new LinkManager();            
            if (!ModelState.IsValid) return RedirectToAction("index");
            linkManager.Add(links);
            linkManager.SaveChanges();
            // following PRG pattern
            return RedirectToAction("index");
        }

        /*
        * Delete link button click. Prepopulate the linkId, link and href
        */
        public IActionResult Delete(int linkId, string link, string href) {
            Link links = new Link();
            links.linkId = linkId;
            links.link = link;
            links.href = href;           
            return View(links);
        }

        /*
        * Delete submit button click. Delete from DB
        */
        [HttpPost]
        public IActionResult DeleteSubmit(Link links) {
            LinkManager linkManager = new LinkManager();  
            linkManager.Remove(links);
            linkManager.SaveChanges();
            return RedirectToAction("index");
        }

        /*
        * Update Link - Category name is dropdown
        */
        public IActionResult Update(int linkId, string categoryName) {
             ViewBag.categoryName = categoryName;           
            LinkManager linkManager = new LinkManager();  

            //get the categories list to populate dropdown
            CategoryManager categoryManager = new CategoryManager();  
            ViewBag.selectList = categoryManager.getSelectList();

            Link link = new Link();           
            link =  linkManager.getLinkById(linkId);
            return View(link);
        } 

        /*
        * Submit the update 
        */
        [HttpPost]
        public IActionResult UpdateSubmit(Link links) {
             LinkManager linkManager = new LinkManager();  
             //Validation, if fails dont submit
            if (!ModelState.IsValid) return RedirectToAction("index");
            linkManager.Update(links);
            linkManager.SaveChanges();
            // following PRG pattern
            return RedirectToAction("index");
        }

        /*
        * Update category
        */
        public IActionResult UpdateCategory(int categoryId, string categoryName) {            
            Category category = new Category();      
            category.categoryId = categoryId;
            category.categoryName = categoryName;
            return View(category);
        } 

        /*
        * Submit the update category
        */
        [HttpPost]
        public IActionResult UpdateCategorySubmit(Category category) {
            CategoryManager categoryManager = new CategoryManager();            
             if (!ModelState.IsValid) return RedirectToAction("index");
            categoryManager.Update(category);
            categoryManager.SaveChanges();
            // following PRG pattern
            return RedirectToAction("index");
        }


    }
}

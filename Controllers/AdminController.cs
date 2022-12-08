using System;
using publicAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace publicAdminPortal.Controllers {

    public class AdminController : Controller {

        private CustomerManager customerManager;

        public AdminController(CustomerManager myManager){
            customerManager = myManager;
        }

        public IActionResult Index() {            
            CategoryLinksManager categoryLinksManager = new CategoryLinksManager();
            categoryLinksManager.getLinksByCategory();
            string feedback = "";            
            if(categoryLinksManager.categories.Count == 0){
                ViewData["feedback"] = "There is no data...";
            }
            return View(categoryLinksManager);                    
        }

        [HttpPost]
        public IActionResult Add(int categoryId, string categoryName) {
            Console.WriteLine(categoryName);
            ViewBag.categoryName = categoryName;
            ViewBag.categoryId = categoryId;
            // construct the Link model
            Link link = new Link();         
            link.categoryId = categoryId;   
            // pass it into the view for populating
            return View(link);
        }

         [HttpPost]
        public IActionResult AddSubmit(Link links) {
            //links.pinned = "false";
            LinkManager linkManager = new LinkManager();            
            if (!ModelState.IsValid) return RedirectToAction("index");
            linkManager.Add(links);
            linkManager.SaveChanges();
            // following PRG pattern
            return RedirectToAction("index");
        }

        public IActionResult Delete(int linkId, string link, string href) {
            Link links = new Link();
            links.linkId = linkId;
            links.link = link;
            links.href = href;           
            return View(links);
        }

        [HttpPost]
        public IActionResult DeleteSubmit(Link links) {
            LinkManager linkManager = new LinkManager();  
            linkManager.Remove(links);
            linkManager.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Update(int linkId, string categoryName) {
             ViewBag.categoryName = categoryName;
            LinkManager linkManager = new LinkManager();  
            Link link = new Link();           
            link =  linkManager.getLinkById(linkId);
            Console.WriteLine("Hereeeyay"+link.href);
            return View(link);
        } 
        [HttpPost]
        public IActionResult UpdateSubmit(Link links) {
             LinkManager linkManager = new LinkManager();  
            if (!ModelState.IsValid) return RedirectToAction("index");
            linkManager.Update(links);
            linkManager.SaveChanges();
            // following PRG pattern
            return RedirectToAction("index");
        }

        public IActionResult UpdateCategory(int categoryId, string categoryName) {            
            Category category = new Category();      
            category.categoryId = categoryId;
            category.categoryName = categoryName;
            return View(category);
        } 
        [HttpPost]
        public IActionResult UpdateCategorySubmit(Category category) {
            CategoryManager categoryManager = new CategoryManager();
            
            //if (!ModelState.IsValid) return RedirectToAction("index");
            categoryManager.Update(category);
            categoryManager.SaveChanges();
            // following PRG pattern
            return RedirectToAction("index");
        }


    }
}

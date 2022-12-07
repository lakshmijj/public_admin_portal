using System;
using publicAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace publicAdminPortal.Controllers {

    public class PublicController : Controller {
     

        public IActionResult Index() {         
            CategoryLinksManager categoryLinksManager = new CategoryLinksManager();
            categoryLinksManager.getLinksByCategory();
            string feedback = "";            
            if(categoryLinksManager.categories.Count == 0){
                ViewData["feedback"] = "There is no data...";
            }else{
                Console.WriteLine(">>>>>>>>>>>>> categories: "+categoryLinksManager.categories.Count);
                Console.WriteLine(">>>>>>>>>>>>> categoryLinks: "+categoryLinksManager.categoryLinks.Count);
            }
            return View(categoryLinksManager);            
        }


    }
}

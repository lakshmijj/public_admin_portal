using System;
using publicAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace publicAdminPortal.Controllers {

    public class PublicController : Controller {
     

        //Landing for the public end
        /*
        * CategoryLinksManager is the model which extracts data from categories and corresponding links
        */
        public IActionResult Index() {         
            CategoryLinksManager categoryLinksManager = new CategoryLinksManager();
            categoryLinksManager.getLinksByCategory();
            //feedback is used to show empty message
            string feedback = "";            
            if(categoryLinksManager.categories.Count == 0){
                ViewData["feedback"] = "There is no data...";
            }
            return View(categoryLinksManager);            
        }


    }
}

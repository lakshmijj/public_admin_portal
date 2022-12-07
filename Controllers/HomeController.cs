using System;
using publicAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace publicAdminPortal.Controllers {

    public class HomeController : Controller {

        private CustomerManager customerManager;

        public HomeController(CustomerManager myManager){
            customerManager = myManager;
        }

        public IActionResult Index() {            
            return View(customerManager);            
        }

        public IActionResult Add() {
            // construct Customer object that will be used to add a new customer
            Customer customer = new Customer();
            // pass it into the view for populating
            return View(customer);
        }

         [HttpPost]
        public IActionResult AddSubmit(Customer customer) {
            if (!ModelState.IsValid) return RedirectToAction("index");
            customerManager.Add(customer);
            customerManager.SaveChanges();
            // following PRG pattern
            return RedirectToAction("index");
        }

        public IActionResult Delete() {
            Customer customer = new Customer();
            ViewBag.selectList = customerManager.getSelectList();
            return View(customer);
        }

        [HttpPost]
        public IActionResult DeleteSubmit(Customer customer) {
            customerManager.Remove(customer);
            customerManager.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Update() {
            Customer customer = new Customer();
            ViewBag.selectList = customerManager.getSelectList();
            customer =  customerManager.getCustomerById(customerManager.selectedCustomer);
            Console.WriteLine("Hereeeyay"+customer.firstName);
            return View(customer);
        }
 
        [HttpPost]
        public IActionResult UpdateSelect(Customer customer) {
            customer = customerManager.getCustomerById(customer.customerID);
            ViewBag.selectList = customerManager.getSelectList();
            return View("Update",customer);
        }

        [HttpPost]
        public IActionResult UpdateSubmit(Customer customer) {
            if (!ModelState.IsValid) return RedirectToAction("index");
            customerManager.Update(customer);
            customerManager.SaveChanges();
            // following PRG pattern
            return RedirectToAction("index");
        }


    }
}

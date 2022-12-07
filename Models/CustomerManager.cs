using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace publicAdminPortal.Models {

    public class CustomerManager: DbContext {

        private DbSet<Customer> tblCustomer{get;set;}

        public int selectedCustomer = 0;
        // -------------------------------------------------- get/sets
        public List<Customer> customers {
            get {
                return tblCustomer.ToList();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8,0,11)));
        }

        public SelectList getSelectList(){
            List<Customer> listData = tblCustomer.OrderBy(c=>c.lastName).ToList();
            selectedCustomer = listData[0].customerID;
            return new SelectList(listData, "customerID", "lastName");
        }

        public Customer getCustomerById(int customerId){
            Console.WriteLine(customerId);
            Customer customer  = tblCustomer
                    .Where(c => c.customerID == customerId)
                    .FirstOrDefault();
            // Customer customer = new Customer();
            // Console.WriteLine(customerRecord.firstName);
            //  customer.customerID = customerRecord.customerID;
            //   customer.firstName = customerRecord.firstName;
            //   customer.lastName = customerRecord.lastName;
            //   customer.address = customerRecord.address;
            //   customer.province = customerRecord.province;
            //   customer.city = customerRecord.city;
            //   customer.postal = customerRecord.postal;
            //   customer.phone = customerRecord.phone;        

              return customer;
        }
       
    }

}
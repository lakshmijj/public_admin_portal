using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace publicAdminPortal.Models {

    public class LinkManager: DbContext {

        private DbSet<Link> tblLink{get;set;}

        public int selectedLink = 0;
        // -------------------------------------------------- get/sets
        public List<Link> links {
            get {
                return tblLink.ToList();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8,0,11)));
        }
       
        public Link getLinkById(int linkId){
            Console.WriteLine("linkId"+linkId);
            Link link  = tblLink
                    .Where(c => c.linkId == linkId)
                    .FirstOrDefault();
              return link;
        }

        
       
    }

}
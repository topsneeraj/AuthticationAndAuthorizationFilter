using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuthticationAndAuthorizationFilter.Models
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext() :base("dbconnect")
        {
           

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
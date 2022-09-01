using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace todo_list.Models
{
    public class datacontext:DbContext
    {
        public datacontext():base(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=todo;Data Source=.")
        {

        }

        public DbSet<monthly> monthlies { get; set; }   
        public DbSet<annualcs> annualcs { get; set; }
        public DbSet<daily> dailies { get; set; }
    }
}
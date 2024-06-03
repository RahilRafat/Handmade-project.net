using project_SWD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Transactions;
using project_SWD.Controllers;

namespace project_SWD.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options) { }
        public DbSet<seller> sellers { get; set; }
        public DbSet<customer> customers { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<payment> payments { get; set; }
        public DbSet<order_item> order_items { get; set; }
        public DbSet<comment> comments { get; set; }
        //public object Login { get; internal set; }
        //public DbSet<Register> acounts { get; set; }


    }
}

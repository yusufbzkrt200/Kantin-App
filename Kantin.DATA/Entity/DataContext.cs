using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantin.DATA.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("appConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Category> Categories { get; set; }

       
    }
}

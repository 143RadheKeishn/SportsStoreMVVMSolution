using SportsStoreDomailLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStoreDomailLibrary.Concrete
{
   public class clsSportsStoreDBContext : DbContext
   {
      public clsSportsStoreDBContext() : base("SportStoreConn") { }
      public DbSet<Product> Products { get; set; }
   }
}

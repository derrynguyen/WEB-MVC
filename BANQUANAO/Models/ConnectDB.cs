using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace BANQUANAO.Models
{
    public class ConnectDB:DbContext
    {
        public ConnectDB() : base("Database") { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<ListProductBill> ListProductBill { get; set; }


    }
}
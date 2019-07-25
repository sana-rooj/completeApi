using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product
                {
                    Product_Id = 1,
                    Product_Name = "Pasta",
                    Product_Des = "white sause",
                    Product_Price = 880,
                    Product_Tax = 50
                },
                 new Product
                 {
                     Product_Id = 2,
                     Product_Name = "Chicken",
                     Product_Des = "grilled",
                     Product_Price = 880,
                     Product_Tax = 50
                 },
                  new Product
                  {
                      Product_Id = 3,
                      Product_Name = "Burger",
                      Product_Des = "labaniese sause",
                      Product_Price = 880,
                      Product_Tax = 50
                  },
                   new Product
                   {
                       Product_Id = 4,
                       Product_Name = "stake",
                       Product_Des = "chicken maushroom sause",
                       Product_Price = 880,
                       Product_Tax = 50
                   },
                    new Product
                    {
                        Product_Id = 5,
                        Product_Name = "pizza",
                        Product_Des = "BBQ",
                        Product_Price = 880,
                        Product_Tax = 50
                    }





                );
            builder.Entity<Permission>().HasData(
                new Permission
                {
                    index = 1,
                    pageName = "front-page",
                    pageUrl = "http://localhost:4000/front-page",
                    pagePermission = "true"
                },
                 new Permission
                 {
                     index=2,
                     pageName = "showresult",
                     pageUrl = "http://localhost:4000/showresult",
                     pagePermission = "true"
                 },
                  new Permission
                  {
                      index=3,
                      pageName = "home",
                      pageUrl = "http://localhost:4000/#",
                      pagePermission = "false"
                  },
                   new Permission
                   {
                       index = 4,
                       pageName = "edit",
                       pageUrl = "http://localhost:4000/edit-data",
                       pagePermission = "false"
                   }
                );

            builder.Entity<UserLoginInfo>().HasData(
              new UserLoginInfo
              {
                  SerialNo = 1,
                  Email = "sanaaroojbutt@hotmail.com",
                  Password = "111111"
              },
              new UserLoginInfo
              {
                  SerialNo = 2,
                  Email = "sahar@hotmail.com",
                  Password = "222222"
              },
               new UserLoginInfo
               {
                   SerialNo = 3,
                   Email = "alina@hotmail.com",
                   Password = "333333"
               }



              ); 


        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<StudentRegisteration> StudentRegisterations { get; set; }
        public DbSet<User> Users { get; set; }

        //public DbSet<ProductRepository> product { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<UserLoginInfo> UserLoginInfo { get; set; }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public object Mapping { get; internal set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order_Products> Orders_Products { get; set; }
        public DbSet<Permission> Permissions { get; set; }

    }
}

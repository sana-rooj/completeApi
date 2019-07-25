﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiProject.Data;

namespace WebApiProject.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation");

                    b.Property<int>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApiProject.Models.Order", b =>
                {
                    b.Property<int>("Order_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Order_Status");

                    b.Property<int>("Total_Items");

                    b.Property<float>("Total_Price");

                    b.Property<float>("Total_Sum_Tax");

                    b.Property<float>("Total_Tax");

                    b.HasKey("Order_Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApiProject.Models.Order_Products", b =>
                {
                    b.Property<int>("SerialNo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Order_Id");

                    b.Property<int?>("Product_Id");

                    b.HasKey("SerialNo");

                    b.HasIndex("Order_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Orders_Products");
                });

            modelBuilder.Entity("WebApiProject.Models.Permission", b =>
                {
                    b.Property<int>("index")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("pageName");

                    b.Property<string>("pagePermission");

                    b.Property<string>("pageUrl");

                    b.HasKey("index");

                    b.ToTable("Permissions");

                    b.HasData(
                        new { index = 1, pageName = "front-page", pagePermission = "true", pageUrl = "http://localhost:4000/front-page" },
                        new { index = 2, pageName = "showresult", pagePermission = "true", pageUrl = "http://localhost:4000/showresult" },
                        new { index = 3, pageName = "home", pagePermission = "false", pageUrl = "http://localhost:4000/#" },
                        new { index = 4, pageName = "edit", pagePermission = "false", pageUrl = "http://localhost:4000/edit-data" }
                    );
                });

            modelBuilder.Entity("WebApiProject.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Gender");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("WebApiProject.Models.Product", b =>
                {
                    b.Property<int>("Product_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Product_Des");

                    b.Property<string>("Product_Name");

                    b.Property<float>("Product_Price");

                    b.Property<float>("Product_Tax");

                    b.HasKey("Product_Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Product_Id = 1, Product_Des = "white sause", Product_Name = "Pasta", Product_Price = 880f, Product_Tax = 50f },
                        new { Product_Id = 2, Product_Des = "grilled", Product_Name = "Chicken", Product_Price = 880f, Product_Tax = 50f },
                        new { Product_Id = 3, Product_Des = "labaniese sause", Product_Name = "Burger", Product_Price = 880f, Product_Tax = 50f },
                        new { Product_Id = 4, Product_Des = "chicken maushroom sause", Product_Name = "stake", Product_Price = 880f, Product_Tax = 50f },
                        new { Product_Id = 5, Product_Des = "BBQ", Product_Name = "pizza", Product_Price = 880f, Product_Tax = 50f }
                    );
                });

            modelBuilder.Entity("WebApiProject.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("WebApiProject.Models.RegisteredUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email_address");

                    b.Property<string>("FileName");

                    b.Property<string>("Job_type");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone_number");

                    b.HasKey("Id");

                    b.ToTable("RegisteredUsers");
                });

            modelBuilder.Entity("WebApiProject.Models.StudentRegisteration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail");

                    b.Property<string>("Filename");

                    b.Property<string>("Name");

                    b.Property<string>("Program");

                    b.HasKey("Id");

                    b.ToTable("StudentRegisterations");
                });

            modelBuilder.Entity("WebApiProject.Models.ToDoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("File");

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Priority");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("WebApiProject.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Employe_Role");

                    b.Property<string>("File");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApiProject.Models.UserLoginInfo", b =>
                {
                    b.Property<int>("SerialNo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("SerialNo");

                    b.ToTable("UserLoginInfo");

                    b.HasData(
                        new { SerialNo = 1, Email = "sanaaroojbutt@hotmail.com", Password = "111111" },
                        new { SerialNo = 2, Email = "sahar@hotmail.com", Password = "222222" },
                        new { SerialNo = 3, Email = "alina@hotmail.com", Password = "333333" }
                    );
                });

            modelBuilder.Entity("WebApiProject.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Choice");

                    b.Property<string>("Comments");

                    b.Property<string>("Email");

                    b.Property<string>("FileNames");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("WebApiProject.Models.Order_Products", b =>
                {
                    b.HasOne("WebApiProject.Models.Order", "Order_ref")
                        .WithMany()
                        .HasForeignKey("Order_Id");

                    b.HasOne("WebApiProject.Models.Product", "Product_ref")
                        .WithMany()
                        .HasForeignKey("Product_Id");
                });
#pragma warning restore 612, 618
        }
    }
}

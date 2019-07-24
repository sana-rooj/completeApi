﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DBContext _context;

        public OrdersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<object> GetOrderAsync([FromRoute] int id)
        {
           
            IQueryable<Object> ProductIds;
            Order OrderObj = new Order();
            OrderObj.Order_Id = id;
            ProductIds = (from products in _context.Orders_Products
                          where products.Order_ref.Equals(OrderObj)
                          select products.Product_ref);
            List<Product> ProductsToShow = ProductIds.Cast<Product>().ToList();
           


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            return new { order, ProductsToShow };

        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Order_Id }, order);
        }
        // GET: api/Orders/5///////////
        //for getting product data https://localhost:44396/api/Orders/add [3, 4]
        [HttpPost("add")]
        public async Task<IActionResult> GetProduct([FromBody] OrderInfo OrderInfoObj)
        {
            List<int> Id = OrderInfoObj.ProductIds;
            string Status = OrderInfoObj.Status;
            int totalItems = 0; float price = 0; float sumTax = 0;
            List<Product> PID = new List<Product>();

            //lastId=(from order in _context.Orders
            // select order.Order_Idd).Max();
            //lastId++;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foreach (int item in Id)
            {
                var product = await _context.Products.FindAsync(item);

                if (product == null)
                {
                    return NotFound();

                }
                PID.Add(product);
                totalItems++;
                price += product.Product_Price;
                sumTax += product.Product_Tax;

            }
            Order OrderUser = new Order();


            OrderUser.Order_Status = Status;
            OrderUser.Total_Items = totalItems;
            OrderUser.Total_Price = price;
            OrderUser.Total_Sum_Tax = sumTax;
            OrderUser.Total_Tax = sumTax;
            await PostOrder(OrderUser);
            foreach (var item in PID)
            {
                Order_Products reference = new Order_Products();
                reference.Order_ref = OrderUser;
                reference.Product_ref = item;
                await PostOrder_Products(reference);
            }

            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult> PostOrder_Products([FromBody] Order_Products order_Products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders_Products.Add(order_Products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder_Products", new { id = order_Products.SerialNo }, order_Products);
        }



    }
}
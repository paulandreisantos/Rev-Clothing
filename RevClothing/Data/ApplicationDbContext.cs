﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevClothing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace RevClothing.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Item> Items {get; set;}
        public DbSet<Categoryclothes> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetail { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

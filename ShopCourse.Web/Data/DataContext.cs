﻿using Microsoft.EntityFrameworkCore;
using ShopCourse.Web.Data.Entities;

namespace ShopCourse.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}

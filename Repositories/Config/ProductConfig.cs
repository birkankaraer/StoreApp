using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasData
                (
                new Product() { ProductId = 1, CategoryId = 1, ImageUrl = "/images/12.jpg", ProductName = "Computer", Price = 17_000, ShowCase = false },
                new Product() { ProductId = 2, CategoryId = 1, ImageUrl = "/images/8.jpg", ProductName = "Keyboard", Price = 6_000, ShowCase = false },
                new Product() { ProductId = 3, CategoryId = 1, ImageUrl = "/images/6.jpg", ProductName = "Mouse", Price = 500, ShowCase = false },
                new Product() { ProductId = 4, CategoryId = 1, ImageUrl = "/images/5.jpg", ProductName = "Monitor", Price = 7_000, ShowCase = true },
                new Product() { ProductId = 5, CategoryId = 1, ImageUrl = "/images/7.jpg", ProductName = "Tablet", Price = 5_000, ShowCase = false },
                new Product() { ProductId = 6, CategoryId = 2, ImageUrl = "/images/1.jpg", ProductName = "Clean Code", Price = 50, ShowCase = false },
                new Product() { ProductId = 7, CategoryId = 2, ImageUrl = "/images/1.jpg", ProductName = "Clean Architecture", Price = 75, ShowCase = false },
                new Product() { ProductId = 8, CategoryId = 1, ImageUrl = "/images/9.jpg", ProductName = "Telephone", Price = 10000, ShowCase = true },
                new Product() { ProductId = 9, CategoryId = 1, ImageUrl = "/images/4.jpg", ProductName = "Headphones", Price = 1000, ShowCase = true }
                );
        }
    }
}

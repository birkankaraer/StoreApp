﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        public virtual void RemoveItem(Product product) =>
            Lines.RemoveAll(l => l.Product.ProductId.Equals(product.ProductId));

        public decimal ComputeTotalValue() => Lines.Sum(l => l.Product.Price * l.Quantity);

        public virtual void Clear() => Lines.Clear();
    }
}

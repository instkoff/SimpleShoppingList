using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SimpleShoppingList.Domain.Models
{
    public class ProductModel
    {
        [BindNever]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [BindNever]
        public string CreateDate { get; set; } = DateTime.Now.ToShortDateString();
        public decimal Price { get; set; }
    }
}

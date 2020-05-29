using System;
using System.Collections.Generic;

namespace SimpleShoppingList.Domain.Models
{
    public class ShoppingListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public List<ProductModel> ProductList { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

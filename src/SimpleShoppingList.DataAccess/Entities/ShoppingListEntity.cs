using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleShoppingList.DataAccess.Entities
{
    public class ShoppingListEntity : BaseEntity
    {
        public ICollection<ProductEntity> ProductList { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalPrice { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShoppingList.DataAccess.Entities
{
    public class ProductEntity :BaseEntity
    {
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

    }
}
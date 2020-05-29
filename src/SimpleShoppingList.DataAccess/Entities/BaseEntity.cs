using System;

namespace SimpleShoppingList.DataAccess.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
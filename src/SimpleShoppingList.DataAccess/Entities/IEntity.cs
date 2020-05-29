using System;

namespace SimpleShoppingList.DataAccess.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
        bool IsActive { get; set; }
        DateTime CreateDate { get; set; }
    }
}
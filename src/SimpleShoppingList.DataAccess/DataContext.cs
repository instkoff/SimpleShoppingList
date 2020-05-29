using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleShoppingList.DataAccess.Entities;

namespace SimpleShoppingList.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<ShoppingListEntity> ShoppingListEntities { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

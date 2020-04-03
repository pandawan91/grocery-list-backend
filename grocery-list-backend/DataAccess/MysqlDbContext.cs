using grocery_list_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace grocery_list_backend.DataAccess
{
    public class MysqlDbContext : DbContext
    {
        public MysqlDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected MysqlDbContext()
        {
        }

        public DbSet<GroceryListItemModel> GroceryListItems { get; set; }
    }
}

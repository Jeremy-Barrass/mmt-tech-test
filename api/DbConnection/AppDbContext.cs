using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Models;

namespace api.DbConnection
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<string> Categories { get; set; }
    }
}
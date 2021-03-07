using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
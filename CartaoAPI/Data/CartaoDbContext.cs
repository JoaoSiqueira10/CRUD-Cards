using CartaoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CartaoAPI.Data
{
    public class CartaoDbContext : DbContext
    {
        public CartaoDbContext(DbContextOptions options) : base(options)
        {
        }

        //Dbset
        public DbSet<Cartao> Cartoes { get; set; }

    }
}

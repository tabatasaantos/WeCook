using Microsoft.EntityFrameworkCore;
using WeCook.Domain;

namespace WeCook.Data
{
    public class WeCookContext : DbContext
    {
        public WeCookContext(DbContextOptions<WeCookContext> options) : base(options) { }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

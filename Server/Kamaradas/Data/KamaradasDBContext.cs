using Kamaradas.Data.Map;
using Kamaradas.Models;
using Microsoft.EntityFrameworkCore;

namespace Kamaradas.Data
{
    public class KamaradasDBContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<MoneyModel> Monies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MoneyMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

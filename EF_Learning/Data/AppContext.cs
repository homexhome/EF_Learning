using EF_Learning.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Learning.Data
{
    public class AppContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }

        public AppContext() {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Database=Ef;Trusted_Connection=True;Trust Server Certificate=true");
        }
    }
}

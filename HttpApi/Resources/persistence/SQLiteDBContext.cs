using Assignment1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpApi.Resources
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = SQLite.db");
        }
    }
}
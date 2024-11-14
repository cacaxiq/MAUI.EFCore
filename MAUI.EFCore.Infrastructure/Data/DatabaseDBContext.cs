using MAUI.EFCore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAUI.EFCore.Infrastructure.Data
{
    public class DatabaseDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DatabaseDBContext()
        {
            Initialize();
        }

        public static bool Initialized { get; protected set; }

        void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;
                Database.Migrate();
            }
        }

        public void Reload()
        {
            Database.CloseConnection();
            Database.OpenConnection();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using UserModelName;

namespace UserDatabase
{
    public class UserDb : DbContext
    {
        public UserDb(DbContextOptions<UserDb> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("UserDatabase");
        }
    }
}

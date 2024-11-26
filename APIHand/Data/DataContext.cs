using APIHand.Entities;
using APIHand.Helper;
using Microsoft.EntityFrameworkCore;

namespace APIHand.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }
        public DataContext()
        {
            
        }
        public DbSet<Command> Commands {  get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(DbHelper.connectionString);
    }
}

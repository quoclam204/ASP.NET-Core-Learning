using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }

        // đại diện cho một bảng trong database.
        public DbSet<Item> Items { get; set; }


    }
}

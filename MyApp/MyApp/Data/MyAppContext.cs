using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }

        // Tạo dữ liệu ban đầu (Seed Data) cho database.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Khai báo khóa chính của bảng ItemClient vì nó không biết cái nào là khóa chính
            // Từ khóa new tạo ra nhiều khóa
            modelBuilder.Entity<ItemClient>().HasKey(ic => new
            {
                ic.ItemId,
                ic.ClientId,
            });

            // chỉ có 1 sản phẩm, sp có nhiều người mua, ItemId là khóa ngoại
            /* Một ItemClient thuộc về 1 Item.
            Một Item có nhiều ItemClients.
            ItemId là khóa ngoại. */
            modelBuilder.Entity<ItemClient>()
                .HasOne(ic => ic.Item)
                .WithMany(i => i.ItemClients)
                .HasForeignKey(ic => ic.ItemId);

            modelBuilder.Entity<ItemClient>()
                .HasOne(ic => ic.Client)
                .WithMany(c => c.ItemClients)
                .HasForeignKey(ic => ic.ClientId);

            // Tạo dữ liệu
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 4, Name = "microphone", Price = 40, SerialNumberId = 10, CategoryId = 1 }
                );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 10, Name = "MIC150" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" }
                );

            // thực hiện các cấu hình mặc định của lớp cha trước, rồi mới áp dụng cấu hình của tôi.
            // dùng để gọi phương thức OnModelCreating() của lớp cha (DbContext) trước hoặc sau khi thêm cấu hình riêng.
            base.OnModelCreating(modelBuilder);
        }

        // Đại diện cho một bảng trong database.
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
    }
}

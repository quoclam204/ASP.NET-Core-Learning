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
            // Tạo dữ liệu
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 4, Name = "microphone", Price = 40, SerialNumberId = 10}
                );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 10, Name = "MIC150"}
                );

            // thực hiện các cấu hình mặc định của lớp cha trước, rồi mới áp dụng cấu hình của tôi.
            // dùng để gọi phương thức OnModelCreating() của lớp cha (DbContext) trước hoặc sau khi thêm cấu hình riêng.
            base.OnModelCreating(modelBuilder);
        }

        // Đại diện cho một bảng trong database.
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }


    }
}

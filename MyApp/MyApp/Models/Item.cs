namespace MyApp.Models
{
    // Sùng để biểu diễn một đối tượng dữ liệu.
    public class Item
    {
        public int Id { get; set; }

        // Ko muốn null nhưng trong tương lại sẽ gán giá trị
        public string Name { get; set; } = null!;
        public double Price { get; set; }

        // Thiết lập quan hệ với SerialNumber
        // Khóa ngoại của bảng SerialNumberId
        public int? SerialNumberId { get; set; }

        // Một Item có thể có một SerialNumber, nhưng cũng có thể không có (null).
        // Đây là đối tượng SerialNumber liên kết với Item, cho phép truy cập thông tin số seri của sản phẩm.
        public SerialNumber? SerialNumber { get; set; } 
    }
}

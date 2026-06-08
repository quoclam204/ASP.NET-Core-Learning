using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    // Số seri hoặc mã số định danh duy nhất của một sản phẩm.
    public class SerialNumber
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;

        // Thiết lập quan hệ với Item
        public Item? Item { get; set; } 

    }
}

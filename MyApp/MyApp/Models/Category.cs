namespace MyApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Một danh mục sẽ có nhiều sản phẩm
        public List<Item>? Items { get; set; }
    }
}

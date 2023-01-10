namespace Models.ProductsManagement
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?  Description { get; set; }
        public Category? Category { get; set; }
        public Inventory? Inventory { get; set; }
        public double Price { get; set; }
        public Discount? Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
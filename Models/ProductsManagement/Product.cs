namespace Models.ProductsManagement
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?  Description { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Inventory? Inventory { get; set; }
        public double Price { get; set; }
        public virtual Discount? Discount { get; set; }
        public string? Image { get; set; }
        public virtual ICollection<Size>? Sizes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
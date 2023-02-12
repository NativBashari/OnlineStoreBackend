using Models.UserManagement;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models.ProductsManagement
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?  Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public double Price { get; set; }
        [ForeignKey("Discount")]
        public int? DiscountId { get; set; }
        public virtual Discount? Discount { get; set; }
        public string? Image { get; set; }
  
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public virtual ICollection<UserCart>? UserCarts { get; set; } = new List<UserCart>();


    }
}
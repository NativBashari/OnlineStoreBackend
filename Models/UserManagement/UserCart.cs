using Models.ProductsManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.UserManagement
{
    public class UserCart
    {
        public int Id { get; set; }
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}

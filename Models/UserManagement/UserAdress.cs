using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UserManagement
{
    public class UserAdress
    {
        [Key]
        public int Id { get; set; }
        public string? AdressLine1 { get; set; }
        public string? AdressLine2 { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}

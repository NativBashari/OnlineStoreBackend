using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public bool IsAdmin { get; set; }
    }
}

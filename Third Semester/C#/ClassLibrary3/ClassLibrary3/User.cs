using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class User:Vaccinated
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; } = null!;
        

        public ICollection<Child> Children { get; set; } = new List<Child>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}

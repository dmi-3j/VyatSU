using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class User:Vaccinated
    {
        public string Address { get; set; } = null!;   
        public ICollection<Child> Children { get; set; } = new List<Child>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public override string GetName()
        {
            return $"{FirstName}";
        }
    }
}

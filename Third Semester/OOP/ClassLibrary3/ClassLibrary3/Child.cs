using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace vaccinecalend
{

    public class Child : Vaccinated
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class CompleteVaccineComponent
    {
        public Guid CompleteComponentId { get; set; }
        public CompleteComponent CompleteComponent { get; set; } = null!;
        public Guid ComponentId { get; set; }
        public VaccineComponent VaccineComponent { get; set; } = null!;
       
    }
}

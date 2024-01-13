using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class VaccineComponent
    {
        [Key]
        public Guid ComponentId { get; set; }
        public string Name { get; set; } = null!;
        public string Structure { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string IntervalOfComponent { get; set; } = null!;
        public Guid VaccineId { get; set; }
        public Vaccine Vaccine { get; set; } = null!;
        
        
   
        public ICollection<CompleteVaccineComponent> CompleteVaccineComponents { get; set; } =  new List<CompleteVaccineComponent>();
    }
}

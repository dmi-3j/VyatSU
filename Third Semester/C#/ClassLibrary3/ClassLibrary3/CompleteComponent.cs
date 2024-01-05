using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace vaccinecalend
{
    public class CompleteComponent
    {
        [Key]
        public Guid CompleteComponentId { get; set; }
        public ICollection<Vaccination> Vaccinations { get; set; } = null!;
        public ICollection<Vaccine> Vaccines { get; set; } = null!;
        public ICollection<CompleteVaccineComponent> CompleteVaccineComponents { get; set; } = null!;

    }
}

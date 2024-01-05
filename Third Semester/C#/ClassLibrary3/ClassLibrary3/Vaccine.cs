using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class Vaccine
    {
        [Key]
        public Guid VaccineId { get; set; }
        public string VaccineName { get; set; } = null!;
        public string ManufactorCountry { get; set; } = null!;
        public string ValidPeriod { get; set; } = null!;

        public ICollection<Vaccination> Vaccinations { get; set; } = null!;
        public ICollection<VaccineComponent> VaccineComponents { get; set; } = null!;
        public Guid CompleteComponentId { get; set; }
        public CompleteComponent CompleteComponent { get; set; } = null!;

    }
}

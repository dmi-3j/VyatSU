using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vaccinecalend
{
    public class CompleteVaccineComponent
    {
        [Key]
        public Guid CompleteComponentId { get; set; }

        public Guid VaccinationId { get; set; }
        public Vaccination Vaccination { get; set; } = null!;
        public VaccineComponent VaccineComponent { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime VaccinationDate { get; set; }
    }
}

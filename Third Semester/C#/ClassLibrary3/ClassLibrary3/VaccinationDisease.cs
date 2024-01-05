using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class VaccinationDisease
    {
        public Guid VaccinationId { get; set; }
        public Vaccination Vaccination { get; set; } = null!;
        public Guid DiseaseId { get; set; }
        public Disease Disease { get; set; } = null!;
    }
}

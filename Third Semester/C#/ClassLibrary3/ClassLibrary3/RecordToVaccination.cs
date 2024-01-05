using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace vaccinecalend
{
    public class RecordToVaccination
    {
        [Key]
        public Guid RecordId { get; set; }
        public DateTime RecordDate { get; set; }

        public Guid VaccinationId { get; set; }
        public Vaccination Vaccination { get; set; } = null!;
        public Guid DiseaseId { get; set; }
        public Disease Disease { get; set; } = null!;
        public Guid VaccinatedId { get; set; }
        public Vaccinated Vaccinated { get; set; } = null!;
        public Guid OrganizationId { get; set; }
        public MedicalOrganization MedicalOrganization { get; set; } = null!;
    }
}

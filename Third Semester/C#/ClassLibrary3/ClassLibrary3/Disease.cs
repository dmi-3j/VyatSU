using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace vaccinecalend
{
    public class Disease
    {
        [Key]
        public Guid DiseaseId { get; set; }
        public string IndicationsToVaccination { get; set; } = null!;
        public ICollection<VaccinationDisease> VaccinationDiseases { get; set; } = null!;
        public ICollection<RecordToVaccination> Records { get; set; } = null!;
        public ICollection<VaccinationDiary> Diseases { get; set; } = null!;
        //public Guid Id { get; set; }
        //public VaccinationDiary VaccinationDiary { get; set; } = null!;

    }
}

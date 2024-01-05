using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class Vaccination
    {
        [Key]
        public Guid VaccinationId { get; set; }
        public string Serial { get; set; } = null!;
        public bool FlagIsDone { get; set; }
        public string TimeInterval { get; set; } = null!;

        public Guid OrganizationId { get; set; }
        public MedicalOrganization MedicalOrganization { get; set; } = null!;

        public ICollection<ReactionOnVaccination> Reactions { get; set; } = null!;
        public ICollection<VaccinationDisease> VaccinationDiseases { get; set; } = null!;
        public Guid VaccineId { get; set; }
        public Vaccine Vaccine { get; set; } = null!;
        public ICollection<RecordToVaccination> Records { get; set; } = null!;
        public ICollection<VaccinationDiary> Vaccinations {  get; set; } = null!;
        //public Guid DiaryId { get; set; } ////
        //public VaccinationDiary VaccinationDiary { get; set; } = null!;
        public Guid CompleteComponentId { get; set; }
        public CompleteComponent CompleteComponent { get; set; } = null!;
    }
}

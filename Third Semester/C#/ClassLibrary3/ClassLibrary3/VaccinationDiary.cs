using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class VaccinationDiary
    {
        [Key]
        public Guid DiaryId { get; set; }
        public Guid VaccinatedId { get; set; }
        public Vaccinated Vaccinated { get; set; } = null!;
        //public ICollection<Disease> Diseases { get; set; } = null!;
        //public ICollection<Vaccination> Vaccinations { get; set; } = null!;

        public Guid VaccinationId { get; set; }
       // public Vaccination Vaccinations { get; set; } = null!;
        public ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();
    }
}
 
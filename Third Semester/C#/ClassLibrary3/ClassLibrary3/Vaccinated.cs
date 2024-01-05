using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class Vaccinated
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<RecordToVaccination>? Records { get; set; } 
       // public Guid DiaryId {  get; set; }
        public ICollection<VaccinationDiary> VaccinationDiary { get; set; } = new List<VaccinationDiary>();
    }
}

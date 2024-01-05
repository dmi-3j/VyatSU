using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace vaccinecalend
{
    public class MedicalOrganization
    {
        [Key]
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Vaccination> Vaccinations { get; set; } = null!;
        public ICollection<RecordToVaccination> Records { get; set; } = null!;

    }
}

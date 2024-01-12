using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vaccinecalend
{
    public class ReactionOnVaccination
    {
        [Key]
        public Guid ReactionId { get; set; }
        public string DescriptionOfReaction { get; set; } = null!;
        
        [Column(TypeName = "date")]
        public DateTime DateOfReaction { get; set; }
        public Guid VaccinationId { get; set; }
        public Vaccination Vaccination { get; set; } = null!;
    }
}

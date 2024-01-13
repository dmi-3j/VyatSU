using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class DBService
    {
        private readonly VaccineCalendarContext _context;

        public DBService(VaccineCalendarContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            user.Password = HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void AddChild(Child child)
        {
            _context.Childs.Add(child);
            _context.SaveChanges();
        }

        public void AddCompleteComponent(CompleteComponent completeComponent)
        {
            _context.ComponentsComplete.Add(completeComponent);
            _context.SaveChanges();
        }

        public void AddCompleteVaccineComponent(CompleteVaccineComponent completeVaccineComponent)
        {
            _context.CompleteVaccines.Add(completeVaccineComponent);
            _context.SaveChanges();
        }


        public void AddMedicalOrganization(MedicalOrganization medicalOrganization)
        {
            _context.MedicalOrganizations.Add(medicalOrganization);
            _context.SaveChanges();
        }

        public void AddReactionOnVaccination(ReactionOnVaccination reactionOnVaccination)
        {
            _context.Reactions.Add(reactionOnVaccination);
            _context.SaveChanges();
        }

        public void AddRecordToVaccination(RecordToVaccination recordToVaccination)
        {
            _context.Records.Add(recordToVaccination);
            _context.SaveChanges();
        }

        public void AddVaccinated(Vaccinated vaccinated)
        {
            _context.Vaccinated.Add(vaccinated);
            _context.SaveChanges();
        }

        public void AddVaccination(Vaccination vaccination)
        {
            _context.Vaccinations.Add(vaccination);
            _context.SaveChanges();
        }

        public void AddVaccinationDiary(VaccinationDiary vaccinationDiary)
        {
            _context.vaccinationDiary.Add(vaccinationDiary);
            _context.SaveChanges();
        }


        public void AddVaccine(Vaccine vaccine)
        {
            _context.Vaccines.Add(vaccine);
            _context.SaveChanges();
        }

        public void AddVaccineComponent(VaccineComponent vaccineComponent)
        {
            _context.Components.Add(vaccineComponent);
            _context.SaveChanges();
        }
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
     }
}

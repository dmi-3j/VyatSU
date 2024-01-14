using vaccinecalend;
using System;
using Microsoft.EntityFrameworkCore;

using (VaccineCalendarContext context = new())
{
    var service = new DBService(context);

    var user = new User
    {
        Username = "user",
        Password = "111",
        FirstName = "John",
        LastName = "Doe",
        DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Utc),
        Address = "Test Address",
        PhoneNumber = "123456789",
        UserRoles =  new List<UserRole> { new UserRole { Role = "USER" } }

    };
    service.AddUser(user);

    var user2 = new User
    {
        Username = "user2",
        Password = "222",
        FirstName = "Алексей",
        LastName = "Мальков",
        DateOfBirth = new DateTime(1990, 5, 15, 0, 0, 0, DateTimeKind.Utc),
        Address = "г. Киров, Ленина, д.16",
        PhoneNumber = "+79128785538",
        UserRoles = new List<UserRole> { new UserRole { Role = "USER" } }
    };
    service.AddUser(user2);

    var user3 = new User
    {
        Username = "user3",
        Password = "333",
        FirstName = "ЧайлдФри",
        LastName = "Петрова",
        DateOfBirth = new DateTime(1990, 5, 15, 0, 0, 0, DateTimeKind.Utc),
        Address = "Бездетова 1",
        PhoneNumber = "987654321",
        UserRoles = new List<UserRole> { new UserRole { Role = "USER" } }
    };
    service.AddUser(user3);
    var admin = new User
    {
        Username = "admin",
        Password = "123",
        FirstName = "Дмитрий",
        LastName = "Субботин",
        DateOfBirth = new DateTime(2001, 5, 15, 0, 0, 0, DateTimeKind.Utc),
        Address = "Студенческий проезд, 3а",
        PhoneNumber = "+79128285795",
        UserRoles = new List<UserRole> { new UserRole { Role = "ADMIN" } }
    };
    service.AddUser(admin);


    var child = new Child
    {
        FirstName = "Alice",
        LastName = "Doe",
        DateOfBirth = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc),
        UserId = user.Id
    };
    service.AddChild(child);

    var child02 = new Child
    {
        FirstName = "Котик",
        LastName = "Doe",
        DateOfBirth = new DateTime(2023, 11, 11, 0, 0, 0, DateTimeKind.Utc),
        UserId = user.Id
    };
    service.AddChild(child02);

    var child1 = new Child
    {
        FirstName = "Ольга",
        LastName = "Малькова",
        DateOfBirth = new DateTime(2015, 2, 10, 0, 0, 0, DateTimeKind.Utc),
        UserId = user2.Id
    };
    service.AddChild(child1);

    var child2 = new Child
    {
        FirstName = "Светлана",
        LastName = "Малькова",
        DateOfBirth = new DateTime(2017, 8, 25, 0, 0, 0, DateTimeKind.Utc),
        UserId = user2.Id
    };
    service.AddChild(child2);

    var child3 = new Child
    {
        FirstName = "Пётр",
        LastName = "Мальков",
        DateOfBirth = new DateTime(2019, 11, 3, 0, 0, 0, DateTimeKind.Utc),
        UserId = user2.Id
    };
    service.AddChild(child3);

    Vaccine vaccine = new Vaccine
    {
        VaccineName = "Спутник V",
        ManufactorCountry = "Россия",
        ValidPeriod = "12 месяцев",
    };
    service.AddVaccine(vaccine);

    Vaccine vaccine2 = new Vaccine
    {
        VaccineName = "COVID-19 Vaccine",
        ManufactorCountry = "Test Country",
        ValidPeriod = "12 months",
    };
    service.AddVaccine(vaccine2);

    MedicalOrganization medicalOrganization = new MedicalOrganization
    {
        OrganizationName = "поликлиника #1",
        Address = "г. Киров, Менделеева, д. 13",
        PhoneNumber = "88332340134"
    };
    service.AddMedicalOrganization(medicalOrganization);

    Vaccination vaccination = new Vaccination
    {
        Serial = "SPTNK001",
        FlagIsDone = false,
        TimeInterval = "1 month",
        //OrganizationId = medicalOrganization.OrganizationId,
        MedicalOrganization = medicalOrganization,
        VaccineId = vaccine2.VaccineId
    };
    service.AddVaccination(vaccination);


    Vaccination vaccination2 = new Vaccination
    {
        Serial = "ABC456",
        FlagIsDone = false,
        TimeInterval = "12 month",
       // OrganizationId = medicalOrganization.OrganizationId,
        MedicalOrganization = medicalOrganization,
        VaccineId = vaccine.VaccineId
    };
    service.AddVaccination(vaccination2);
    Vaccination vaccination3 = new Vaccination
    {
        Serial = "вакцина ребенок тест",
        FlagIsDone = false,
        TimeInterval = "12 month",
        //OrganizationId = medicalOrganization.OrganizationId,
        MedicalOrganization = medicalOrganization,
        VaccineId = vaccine.VaccineId
    };
    service.AddVaccination(vaccination3);
    Vaccination vaccination4 = new Vaccination
    {
        Serial = "вакцина ребенок тест2",
        FlagIsDone = false,
        TimeInterval = "12 month",
        //OrganizationId = medicalOrganization.OrganizationId,
        MedicalOrganization = medicalOrganization,
        VaccineId = vaccine.VaccineId
    };
    service.AddVaccination(vaccination4);


    //ReactionOnVaccination reactionOnVaccination = new ReactionOnVaccination
    //{
    //    DescriptionOfReaction = "Test Reaction",
    //    DateOfReaction = DateTime.UtcNow,
    //    VaccinationId = vaccination.VaccinationId
    //};
    // service.AddReactionOnVaccination(reactionOnVaccination);

    // Создаем запись в дневнике вакцинации
    var vaccinationDiaryEntry = new VaccinationDiary
    {
        VaccinatedId = user2.Id,
        VaccinationId = vaccination.VaccinationId,

    };
    vaccinationDiaryEntry.Vaccinations.Add(vaccination);
    //// Добавляем запись в дневник вакцинации в базу данных
    service.AddVaccinationDiary(vaccinationDiaryEntry);

    //var vaccinationDiaryEntry2 = new VaccinationDiary
    //{
    //    VaccinatedId = user2.Id,
    //    VaccinationId = vaccination2.VaccinationId,

    //};
    //vaccinationDiaryEntry2.Vaccinations.Add(vaccination2);
    //// Добавляем запись в дневник вакцинации в базу данных
    //service.AddVaccinationDiary(vaccinationDiaryEntry2);

    ////добавляем записи для ребенка
    //var vaccinationDiaryEntry3 = new VaccinationDiary
    //{
    //    VaccinatedId = child1.Id,
    //    VaccinationId = vaccination3.VaccinationId,

    //};
    //vaccinationDiaryEntry3.Vaccinations.Add(vaccination3);
    //// Добавляем запись в дневник вакцинации в базу данных
    //service.AddVaccinationDiary(vaccinationDiaryEntry3);

    //var vaccinationDiaryEntry4 = new VaccinationDiary
    //{
    //    VaccinatedId = child1.Id,
    //    VaccinationId = vaccination4.VaccinationId,

    //};
    //vaccinationDiaryEntry4.Vaccinations.Add(vaccination4);
    //// Добавляем запись в дневник вакцинации в базу данных
    //service.AddVaccinationDiary(vaccinationDiaryEntry4);



    //var recordToVaccination = new RecordToVaccination
    //{
    //    RecordDate = DateTime.UtcNow,
    //    VaccinationId = vaccination.VaccinationId,
    //    DiseaseId = disease.DiseaseId, // Замените на реальный DiseaseId
    //    VaccinatedId = user.Id, // Замените на реальный VaccinatedId
    //    MedicalOrganization = medicalOrganization,
    //    OrganizationId = medicalOrganization.OrganizationId
    //};
    //service.AddRecordToVaccination(recordToVaccination);

    Console.WriteLine("\n////////////////////");
    Console.WriteLine("Дети юзера");

    var usersWithChildren = context.Users
                    .Include(u => u.Children)
                    .ToList();

    foreach (var u in usersWithChildren)
    {
        Console.WriteLine($"User: {u.FirstName} {u.LastName}");
        foreach (var c in u.Children)
        {
            Console.WriteLine($"  Child: {c.FirstName} {c.LastName}");
        }
    }

    Console.WriteLine("\n////////////////////");
    Console.WriteLine("Только вакцинация чела");
    var userWithVaccinations = context.Users
     .Include(u => u.VaccinationDiary)
         .ThenInclude(vd => vd.Vaccinations)
             .ThenInclude(v => v.MedicalOrganization)
             
             .FirstOrDefault(u => u.Id == user2.Id);

    if (userWithVaccinations != null)
    {
        Console.WriteLine($"User: {userWithVaccinations.FirstName} {userWithVaccinations.LastName}");

        var vaccinationDiary = userWithVaccinations.VaccinationDiary;
        if (vaccinationDiary != null)
        {
            foreach (var vaccinationItem in vaccinationDiary)
            {
                var vc = vaccinationItem.Vaccinations;
                foreach (var v in vc)
                {
                    Console.WriteLine($"  \nVaccination: {v.Serial}");
                    var vaccinee = v.Vaccine;
                    Console.WriteLine($"Vaccine: {vaccinee.VaccineName}");
                    var medicalOrganizationn = v.MedicalOrganization;
                    Console.WriteLine($"Medical Organization: {medicalOrganizationn.OrganizationName}");
                }
            }
        }
    }
    Console.WriteLine("\n/////////////////////////////");
    Console.WriteLine("Вакцинация чела и детей");
    var userVacc = context.Users
    .Include(u => u.VaccinationDiary)
        .ThenInclude(vd => vd.Vaccinations)
            .ThenInclude(v => v.MedicalOrganization)
    .Include(u => u.Children)
        .ThenInclude(c => c.VaccinationDiary)
            .ThenInclude(vd => vd.Vaccinations)
                .ThenInclude(v => v.MedicalOrganization)
    .FirstOrDefault(u => u.Id == user2.Id);

    if (userVacc != null)
    {
        Console.WriteLine($"User: {userVacc.FirstName} {userVacc.LastName}");

        // Вакцинации пользователя
        var userVaccinationDiary = userVacc.VaccinationDiary;
        if (userVaccinationDiary != null)
        {
            foreach (var vaccinationItem in userVaccinationDiary)
            {
                var vc = vaccinationItem.Vaccinations;
                foreach (var v in vc)
                {
                    Console.WriteLine($"  \nVaccination: {v.Serial}");
                    var vaccinee = v.Vaccine;
                    Console.WriteLine($"Vaccine: {vaccinee.VaccineName}");
                    var medicalOrganizationn = v.MedicalOrganization;
                    Console.WriteLine($"Medical Organization: {medicalOrganizationn.OrganizationName}");
                }
            }
        }

        // Вакцинации детей пользователя
        //var children = userVacc.Children;
        //foreach (var c in children)
        //{
        //    var childVaccinationDiary = c.VaccinationDiary;
        //    if (childVaccinationDiary != null)
        //    {
        //        Console.WriteLine($"\nChild: {c.FirstName} {c.LastName}");
        //        if (childVaccinationDiary.Count == 0) Console.WriteLine("Нет вакцинаций");
        //        foreach (var vaccinationItem in childVaccinationDiary)
        //        {
        //            var vc = vaccinationItem.Vaccinations;
        //            foreach (var v in vc)
        //            {
        //                Console.WriteLine($"  \nVaccination: {v.Serial}");
        //                var vaccinee = v.Vaccine;
        //                Console.WriteLine($"Vaccine: {vaccinee.VaccineName}");
        //                var medicalOrganizationn = v.MedicalOrganization;
        //                Console.WriteLine($"Medical Organization: {medicalOrganizationn.OrganizationName}");
        //            }
        //        }
        //    }
        //}
    }

    //else
    //{
    //    Console.WriteLine("User not found or has no vaccinations.");
    //}
}
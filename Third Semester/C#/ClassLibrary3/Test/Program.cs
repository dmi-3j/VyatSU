using vaccinecalend;
using System;
using Microsoft.EntityFrameworkCore;

using (VaccineCalendarContext context = new())
{
    var service = new DBService(context);

    var user = new User
    {
        Username = "testuser",
        Password = "testpassword",
        FirstName = "John",
        LastName = "Doe",
        DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Utc),
        Address = "Test Address",
        PhoneNumber = "123456789"
    };
    service.AddUser(user);

    var user2 = new User
    {
        Username = "newuser",
        Password = "newpassword",
        FirstName = "Jane",
        LastName = "Smith",
        DateOfBirth = new DateTime(1990, 5, 15, 0, 0, 0, DateTimeKind.Utc),
        Address = "New Address",
        PhoneNumber = "987654321"
    };
    service.AddUser(user2);


    //var child = new Child
    //{
    //    FirstName = "Alice",
    //    LastName = "Doe",
    //    DateOfBirth = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc),
    //    UserId = user.Id
    //};
    //service.AddChild(child);

    //var child02 = new Child
    //{
    //    FirstName = "Котик",
    //    LastName = "Doe",
    //    DateOfBirth = new DateTime(2023, 11, 11, 0, 0, 0, DateTimeKind.Utc),
    //    UserId = user.Id
    //};
    //service.AddChild(child02);


    // Создание трех детей для нового пользователя
    //var child1 = new Child
    //{
    //    FirstName = "Olga",
    //    LastName = "Smith",
    //    DateOfBirth = new DateTime(2015, 2, 10, 0, 0, 0, DateTimeKind.Utc),
    //    UserId = user2.Id
    //};
    //service.AddChild(child1);

    //var child2 = new Child
    //{
    //    FirstName = "Sally",
    //    LastName = "Smith",
    //    DateOfBirth = new DateTime(2017, 8, 25, 0, 0, 0, DateTimeKind.Utc),
    //    UserId = user2.Id
    //};
    //service.AddChild(child2);

    //var child3 = new Child
    //{
    //    FirstName = "Megan",
    //    LastName = "Smith",
    //    DateOfBirth = new DateTime(2019, 11, 3, 0, 0, 0, DateTimeKind.Utc),
    //    UserId = user2.Id
    //};
    //service.AddChild(child3);

    var completeComponent = new CompleteComponent();
    service.AddCompleteComponent(completeComponent);

    Vaccine vaccine = new Vaccine
    {
        VaccineName = "COVID-19 Vaccine",
        ManufactorCountry = "Test Country",
        ValidPeriod = "12 months",
        CompleteComponentId = completeComponent.CompleteComponentId
    };
    service.AddVaccine(vaccine);

    MedicalOrganization medicalOrganization = new MedicalOrganization
    {
        OrganizationName = "Test Hospital",
        Address = "Hospital Address",
        PhoneNumber = "987654321"
    };
    service.AddMedicalOrganization(medicalOrganization);

    Vaccination vaccination = new Vaccination
    {
        Serial = "ABC123",
        FlagIsDone = false,
        TimeInterval = "1 month",
        OrganizationId = medicalOrganization.OrganizationId,
        MedicalOrganization = medicalOrganization,
        VaccineId = vaccine.VaccineId,
        CompleteComponentId = completeComponent.CompleteComponentId // Убедитесь, что это значение существует
    };
    service.AddVaccination(vaccination);


    Vaccination vaccination2 = new Vaccination
    {
        Serial = "ABC456",
        FlagIsDone = false,
        TimeInterval = "12 month",
        OrganizationId = medicalOrganization.OrganizationId,
        MedicalOrganization = medicalOrganization,
        VaccineId = vaccine.VaccineId,
        CompleteComponentId = completeComponent.CompleteComponentId // Убедитесь, что это значение существует
    };
    service.AddVaccination(vaccination2);




    //ReactionOnVaccination reactionOnVaccination = new ReactionOnVaccination
    //{
    //    DescriptionOfReaction = "Test Reaction",
    //    DateOfReaction = DateTime.UtcNow,
    //    VaccinationId = vaccination.VaccinationId
    //};
    // service.AddReactionOnVaccination(reactionOnVaccination);

    var disease = new Disease
    {
        IndicationsToVaccination = "Test Indications"
    };
    service.AddDisease(disease);

    var disease2 = new Disease
    {
        IndicationsToVaccination = "Test Indications"
    };
    service.AddDisease(disease2);


    // Создаем запись в дневнике вакцинации
    var vaccinationDiaryEntry = new VaccinationDiary
    {
        VaccinatedId = user2.Id,
        VaccinationId = vaccination.VaccinationId,
        DiseaseId = disease.DiseaseId
    };
    vaccinationDiaryEntry.Vaccinations.Add(vaccination);
    // Добавляем запись в дневник вакцинации в базу данных
    service.AddVaccinationDiary(vaccinationDiaryEntry);

    var vaccinationDiaryEntry2 = new VaccinationDiary
    {
        VaccinatedId = user2.Id,
        VaccinationId = vaccination2.VaccinationId,
        DiseaseId = disease2.DiseaseId
    };
    vaccinationDiaryEntry2.Vaccinations.Add(vaccination2);
    // Добавляем запись в дневник вакцинации в базу данных
    service.AddVaccinationDiary(vaccinationDiaryEntry2);


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



    //var usersWithChildren = context.Users
    //                .Include(u => u.Children)
    //                .ToList();

    //foreach (var u in usersWithChildren)
    //{
    //    Console.WriteLine($"User: {u.FirstName} {u.LastName}");
    //    foreach (var c in u.Children)
    //    {
    //        Console.WriteLine($"  Child: {c.FirstName} {c.LastName}");
    //    }
    //}

    //////////////////////////
    //Guid userId = user.Id;

    //// Найти запись в дневнике вакцинации для конкретного пользователя
    //var diaryEntry = context.vaccinationDiary
    //    .Where(entry => entry.VaccinatedId == userId)
    //    .FirstOrDefault();

    //// Проверка наличия записи в дневнике
    //if (diaryEntry != null)
    //{
    //    Guid diaryId = diaryEntry.DiaryId;
    //    var vaccinationsInDiary = context.Vaccinations
    //    .Where(v => v.Vaccinations.Any(vd => vd.DiaryId == diaryId))
    //    .ToList();
    //    Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
    //    // Вывести информацию о вакцинациях
    //    foreach (var vaccinationn in vaccinationsInDiary)
    //    {
    //        Console.WriteLine($"VaccinationId: {vaccinationn.VaccinationId}, Serial: {vaccinationn.Serial}");
    //        // Дополнительная информация о вакцинации, если необходимо
    //    }
    //    Console.WriteLine($"DiaryId for user with Id {userId}: {diaryId}");
    //}
    ////////////////////////


    ////var userWithVaccinations = context.Users
    ////.Include(u => u.VaccinationDiary)
    ////    .ThenInclude(vd => vd.Vaccinations)
    ////        .ThenInclude(v => v.MedicalOrganization)
    ////.FirstOrDefault(u => u.Id == newUser.Id);

    ////Console.WriteLine(newUser.Id);
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
                    Console.WriteLine($"  Vaccination: {v.Serial}");
                    var vaccinee = v.Vaccine;
                    Console.WriteLine($"Vaccine: {vaccinee.VaccineName}");
                    var medicalOrganizationn = v.MedicalOrganization;
                    Console.WriteLine($"Medical Organization: {medicalOrganizationn.OrganizationName}");
                }
            }
        }
    }
    //else
    //{
    //    Console.WriteLine("User not found or has no vaccinations.");
    //}
}
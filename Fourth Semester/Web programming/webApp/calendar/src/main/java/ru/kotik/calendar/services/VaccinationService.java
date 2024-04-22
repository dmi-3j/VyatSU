package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.*;
import ru.kotik.calendar.repositories.VaccinationRepository;
import ru.kotik.calendar.specifications.VaccinationSpecification;


import java.util.ArrayList;
import java.util.Comparator;
import java.util.Date;
import java.util.List;

@Service
public class VaccinationService {
    @Autowired
    private VaccinationRepository vaccinationRepository;

    @Autowired
    private UserService userService;

    @Autowired
    private CompleteComponentService completeComponentService;


    public void saveVaccination(String serial, User user, Vaccine vaccine, VaccineComponent component, MedicalOrganization organization) {
        Vaccination vaccination = new Vaccination();
        vaccination.setSerial(serial);
        vaccination.setUser(user);
        vaccination.setVaccine(vaccine);
        vaccination.setCompleteComponents(new ArrayList<>());
        vaccinationRepository.save(vaccination);
        user.getVaccinations().add(vaccination);
        userService.saveUser(user);
        CompleteVaccineComponent completeVaccineComponent = new CompleteVaccineComponent();
        completeVaccineComponent.setVaccination(vaccination);
        completeVaccineComponent.setVaccineComponent(component);
        completeVaccineComponent.setMedicalOrganization(organization);
        completeVaccineComponent.setVaccinationdate(new Date());
        completeComponentService.saveCompleteVaccineComponent(completeVaccineComponent);
        vaccination.getCompleteComponents().add(completeVaccineComponent);
        vaccinationRepository.save(vaccination);
    }

    public void addCompleteComponentToVaccination(Vaccination vaccination, VaccineComponent component, MedicalOrganization medicalOrganization) {
        CompleteVaccineComponent completeVaccineComponent = new CompleteVaccineComponent();
        completeVaccineComponent.setVaccination(vaccination);
        completeVaccineComponent.setVaccineComponent(component);
        completeVaccineComponent.setMedicalOrganization(medicalOrganization);
        completeVaccineComponent.setVaccinationdate(new Date());
        completeComponentService.saveCompleteVaccineComponent(completeVaccineComponent);
    }

    public List<Vaccination> getVaccinationsByUser(User user) {
        List<Vaccination> vaccinations = vaccinationRepository.getVaccinationsByUser(user);
        for (Vaccination v : vaccinations) {
            v.getCompleteComponents().sort(Comparator.comparing(CompleteVaccineComponent::getVaccinationdate).reversed());
        }
        return vaccinations;
    }

    public List<Vaccination> getVaccinationsByUser(User user, String serial, String vaccineName) {
        Specification<Vaccination> specification = Specification
                .where(VaccinationSpecification.hasUserAndSerial(user, serial))
                .and(VaccinationSpecification.hasUserAndVaccineName(user, vaccineName));
        List<Vaccination> vaccinations = vaccinationRepository.findAll(specification);
        for (Vaccination v : vaccinations) {
            v.getCompleteComponents().sort(Comparator.comparing(CompleteVaccineComponent::getVaccinationdate).reversed());
        }
        return vaccinations;
    }

    public Vaccination getById(int id) {
        return vaccinationRepository.findById(id).orElse(null);
    }

}

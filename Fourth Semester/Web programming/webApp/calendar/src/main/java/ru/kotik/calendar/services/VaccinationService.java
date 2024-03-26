package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.*;
import ru.kotik.calendar.repositories.VaccinationRepository;

import java.util.ArrayList;
import java.util.Date;

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




}

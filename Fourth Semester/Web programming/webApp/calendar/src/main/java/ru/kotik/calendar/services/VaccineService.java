package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.entities.Vaccine;
import ru.kotik.calendar.repositories.VaccineRepository;

@Service
public class VaccineService {

    @Autowired
    private VaccineRepository repository;
    public void saveVaccine(Vaccine vaccine) {
        repository.save(vaccine);
    }
}

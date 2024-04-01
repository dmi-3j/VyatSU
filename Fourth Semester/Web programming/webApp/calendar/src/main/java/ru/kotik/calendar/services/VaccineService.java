package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.entities.Vaccine;
import ru.kotik.calendar.entities.VaccineComponent;
import ru.kotik.calendar.repositories.VaccineRepository;
import ru.kotik.calendar.specifications.VaccineSpecification;

import java.util.List;
import java.util.UUID;

@Service
public class VaccineService {

    @Autowired
    private VaccineRepository repository;

    public void saveVaccine(Vaccine vaccine) {
        repository.save(vaccine);
    }

    public List<Vaccine> getAllVaccines() {
        return repository.findAll();
    }

    public List<Vaccine> getAllVaccines(String name, String country, String valid) {
        Specification<Vaccine> specification = Specification
                .where(VaccineSpecification.hasName(name))
                .and(VaccineSpecification.hasCountry(country))
                .and(VaccineSpecification.hasValidPeriod(valid));
        return repository.findAll(specification);
    }

    public Vaccine getVaccineById(int id) {
        return repository.getVaccinesById(id);
    }

}

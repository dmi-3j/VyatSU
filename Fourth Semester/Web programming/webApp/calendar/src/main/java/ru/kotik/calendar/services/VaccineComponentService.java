package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.VaccineComponent;
import ru.kotik.calendar.repositories.VaccineComponentRepository;

@Service
public class VaccineComponentService {

    @Autowired
    private VaccineComponentRepository vaccineComponentRepository;

    public void saveVaccineComponent(VaccineComponent vaccineComponent) {
        vaccineComponentRepository.save(vaccineComponent);
    }
}

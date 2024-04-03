package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.VaccineComponent;
import ru.kotik.calendar.repositories.VaccineComponentRepository;

import java.util.List;
import java.util.UUID;

@Service
public class VaccineComponentService {

    @Autowired
    private VaccineComponentRepository vaccineComponentRepository;

    public void saveVaccineComponent(VaccineComponent vaccineComponent) {
        vaccineComponentRepository.save(vaccineComponent);
    }

    public List<VaccineComponent> getComponentsByVaccineId(int id) {
        return vaccineComponentRepository.getVaccineComponentsByVaccineId(id);
    }

    public VaccineComponent getComponentById(int id) {
        return vaccineComponentRepository.getVaccineComponentById(id);
    }
}

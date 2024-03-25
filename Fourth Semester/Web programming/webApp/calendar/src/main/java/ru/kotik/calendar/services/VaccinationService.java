package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.repositories.VaccinationRepository;

@Service
public class VaccinationService {
    @Autowired
    private VaccinationRepository vaccinationRepository;

}

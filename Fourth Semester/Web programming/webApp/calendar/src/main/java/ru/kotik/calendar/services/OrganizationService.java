package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.MedicalOrganzation;
import ru.kotik.calendar.repositories.OrganizationRepository;

@Service
public class OrganizationService {

    @Autowired
    private OrganizationRepository organizationRepository;

    public void saveOrganization(MedicalOrganzation medicalOrganzation) {
        organizationRepository.save(medicalOrganzation);
    }
}

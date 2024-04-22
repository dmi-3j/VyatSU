package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.MedicalOrganization;
import ru.kotik.calendar.repositories.OrganizationRepository;
import ru.kotik.calendar.specifications.MedOrgSpecification;

import java.util.List;

@Service
public class OrganizationService {

    @Autowired
    private OrganizationRepository organizationRepository;

    public MedicalOrganization getMedicalOrganizationById(int id) {
        return organizationRepository.findMedicalOrganizationById(id);
    }

    public List<MedicalOrganization> getAllOrganizations() {
        return organizationRepository.findAll();
    }

    public List<MedicalOrganization> getAllOrganizations(String name, String address, String phone) {
        Specification<MedicalOrganization> specification = Specification
                .where(MedOrgSpecification.hasName(name))
                .and(MedOrgSpecification.hasAddress(address))
                .and(MedOrgSpecification.hasPhone(phone));
        return organizationRepository.findAll(specification);
    }

    public void saveMedicalOrganization(MedicalOrganization medicalOrganization) {
        organizationRepository.save(medicalOrganization);
    }

    public void update(MedicalOrganization exist, MedicalOrganization updated) {
        if (!(updated.getOrganizationName() == null) && !updated.getOrganizationName().isBlank())
            exist.setOrganizationName(updated.getOrganizationName());
        if (!(updated.getAddress() == null) && !updated.getAddress().isBlank()) exist.setAddress(updated.getAddress());
        if (!(updated.getPhoneNumber() == null) && !updated.getPhoneNumber().isBlank())
            exist.setPhoneNumber(updated.getPhoneNumber());
        organizationRepository.save(exist);
    }
}

package com.example.lr15.services;

import com.example.lr15.Specifications.OrganizationSpecifications;
import com.example.lr15.entities.MedicalOrganization;
import com.example.lr15.repositories.OrganizationRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.stereotype.Service;
import java.util.List;
@Service
public class OrganizationService {
    private final OrganizationRepository repository;

    @Autowired
    public OrganizationService(OrganizationRepository repository) {
        this.repository = repository;
    }

    public MedicalOrganization getById(Integer id) {
        return repository.findById(id).orElse(null);
    }

    public Page<MedicalOrganization> getAllOrganizations(Pageable pageable) {
        return repository.findAll(pageable);
    }
    public Page<MedicalOrganization> getAllOrganizations(String name, String address, Integer timeofwork, Pageable pageable) {
        Specification<MedicalOrganization> specification = Specification
                .where(OrganizationSpecifications.hasName(name))
                .and(OrganizationSpecifications.hasAddress(address))
                .and(OrganizationSpecifications.hasTimeOfWork(timeofwork));
        return repository.findAll(specification, pageable);
    }
    public void add(MedicalOrganization medicalOrganization) {
        repository.save(medicalOrganization);
    }

    public void delete(MedicalOrganization medicalOrganization) {
        repository.delete(medicalOrganization);
    }

    public void update(MedicalOrganization exist, MedicalOrganization updated) {
        if (!updated.getName().isBlank()) exist.setName(updated.getName());
        if (!updated.getAddress().isBlank()) exist.setAddress(updated.getAddress());
        if (!updated.getPhone().isBlank()) exist.setPhone(updated.getPhone());
        if (updated.getOpeningtime() != null) exist.setOpeningtime(updated.getOpeningtime());
        if (updated.getClosingtime() != null) exist.setClosingtime(updated.getClosingtime());
        repository.save(exist);
    }
}

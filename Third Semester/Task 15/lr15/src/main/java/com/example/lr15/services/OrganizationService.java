package com.example.lr15.services;

import com.example.lr15.Specifications.OrganizationSpecifications;
import com.example.lr15.entities.MedicalOrganization;
import com.example.lr15.repositories.OrganizationRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
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
        MedicalOrganization organization = repository.findById(id).orElse(null);
        if(organization == null) throw new UsernameNotFoundException("");
        return organization;
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
    public List<MedicalOrganization> getTopOrganizations() {
        Pageable topPageable = PageRequest.of(0, 3, Sort.by(Sort.Order.desc("views")));
        Page<MedicalOrganization> topOrganizationsPage = repository.findAll(topPageable);
        return topOrganizationsPage.getContent();
    }
    public void add(MedicalOrganization medicalOrganization) {
        medicalOrganization.setViews(0);
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
    public void incViews(MedicalOrganization medicalOrganization){
        medicalOrganization.setViews(medicalOrganization.getViews() + 1);
        repository.save(medicalOrganization);
    }
}

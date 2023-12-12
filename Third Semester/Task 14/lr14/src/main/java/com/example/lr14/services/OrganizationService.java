package com.example.lr14.services;

import com.example.lr14.entities.MedicalOrganization;
import com.example.lr14.repositories.OrganizationRepository;
import jakarta.servlet.Filter;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.ArrayList;

@Service
public class OrganizationService {
    private OrganizationRepository repository;

    @Autowired
    public void setRepository(OrganizationRepository repository) {
        this.repository = repository;
    }
    public MedicalOrganization getById(Integer id) {
        return repository.findById(id);
    }
    public List<MedicalOrganization> getAllOrganizations() {
        return repository.getAllOrganizations();
    }
    public List<MedicalOrganization> getAllOrganizations(String name, String address, String timeofwork) {
        return repository.getAllOrganizations(name, address, timeofwork);
    }
    public void add(MedicalOrganization medicalOrganization) {
        repository.save(medicalOrganization);
    }
    public void delete(MedicalOrganization medicalOrganization) {
        repository.delete(medicalOrganization);
    }
    public void update(MedicalOrganization medicalOrganization, MedicalOrganization updated) {
        repository.update(medicalOrganization, updated);
    }
}

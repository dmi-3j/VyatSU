package com.example.lr14.services;

import com.example.lr14.entities.MedicalOrganization;
import com.example.lr14.repositories.OrganizationRepository;
import jakarta.servlet.Filter;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.ArrayList;
import java.util.stream.Collectors;

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
    public List<MedicalOrganization> getAllOrganizations() {
        return repository.findAll();
    }
    public List<MedicalOrganization> getAllOrganizations(String name, String address, String timeofwork) {
        return repository.findAll().stream()
                .filter(o -> name == null || o.getName().contains(name))
                .filter(o -> address == null || o.getAddress().contains(address))
                .filter(o -> timeofwork == null || o.getTimeOfWork().contains(timeofwork))
                .collect(Collectors.toList());
    }
    public void add(MedicalOrganization medicalOrganization) {
        repository.save(medicalOrganization);
    }
    public void delete(MedicalOrganization medicalOrganization) {
        repository.delete(medicalOrganization);
    }
    public void update(MedicalOrganization exist, MedicalOrganization updated) {
        if (!updated.getName().isBlank()) exist.setName(updated.getName());
        if(!updated.getAddress().isBlank()) exist.setAddress(updated.getAddress());
        if (!updated.getPhone().isBlank()) exist.setPhone(updated.getPhone());
        if(!updated.getTimeOfWork().isBlank()) exist.setTimeOfWork(updated.getTimeOfWork());
        repository.save(exist);
    }
}

package com.example.lr14.repositories;

import com.example.lr14.entities.MedicalOrganization;
import jakarta.annotation.PostConstruct;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Controller;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

//@Component
public interface OrganizationRepository extends JpaRepository<MedicalOrganization, Integer> {

//    private List<MedicalOrganization> organizations;
//
//    @PostConstruct
//    private void init() {
//        organizations = new ArrayList<>();
//        organizations.add(new MedicalOrganization(1,"Больница №1", "Кирова 1", "88005553535", "8-20" ));
//        organizations.add(new MedicalOrganization(2,"Больница №5", "Ленина 76", "88005294535", "7-17" ));
//        organizations.add(new MedicalOrganization(3,"Травмпункт", "Менделеева 16", "88332553535", "10-20" ));
//    }
//    public MedicalOrganization findById(Integer id) {
//        return organizations.stream().filter(o -> o.getId().equals(id)).findFirst().get();
//    }
//    public List<MedicalOrganization> getAllOrganizations() {
//        return organizations;
//    }
//    public List<MedicalOrganization> getAllOrganizations(String name, String address, String timeofwork) {
//        return organizations.stream()
//                .filter(o -> name == null || o.getName().contains(name))
//                .filter(o -> address == null || o.getAddress().contains(address))
//                .filter(o -> timeofwork == null || o.getTimeOfWork().equals(timeofwork))
//                .collect(Collectors.toList());
//    }
//    public void save(MedicalOrganization medicalOrganization) {
//        organizations.add(medicalOrganization);
//    }
//    public void delete(MedicalOrganization medicalOrganization) {
//        organizations.remove(medicalOrganization);
//    }
//    public void update(MedicalOrganization exist, MedicalOrganization updated) {
//            exist.setName(updated.getName());
//            exist.setAddress(updated.getAddress());
//            exist.setPhone(updated.getPhone());
//            exist.setTimeOfWork(updated.getTimeOfWork());
//    }
}

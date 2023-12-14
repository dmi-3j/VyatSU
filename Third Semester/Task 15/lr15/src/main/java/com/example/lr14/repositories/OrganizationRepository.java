package com.example.lr14.repositories;

import com.example.lr14.entities.MedicalOrganization;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


@Repository
public interface OrganizationRepository extends JpaRepository<MedicalOrganization, Integer> {

}

package com.example.lr15.repositories;

import com.example.lr15.entities.MedicalOrganization;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.yaml.snakeyaml.events.Event;


@Repository
public interface OrganizationRepository extends JpaRepository<MedicalOrganization,Integer> {
}

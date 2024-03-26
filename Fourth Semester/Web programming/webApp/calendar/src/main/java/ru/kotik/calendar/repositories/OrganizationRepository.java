package ru.kotik.calendar.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.MedicalOrganization;

import java.util.UUID;

@Repository
public interface OrganizationRepository extends JpaRepository<MedicalOrganization, Integer>, JpaSpecificationExecutor<MedicalOrganization> {
    MedicalOrganization findMedicalOrganizationById(int id);
}

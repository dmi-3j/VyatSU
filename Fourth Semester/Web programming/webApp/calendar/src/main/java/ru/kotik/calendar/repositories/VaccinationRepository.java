package ru.kotik.calendar.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.Vaccination;

@Repository
public interface VaccinationRepository extends JpaRepository<Vaccination, Integer>, JpaSpecificationExecutor<Vaccination> {
}

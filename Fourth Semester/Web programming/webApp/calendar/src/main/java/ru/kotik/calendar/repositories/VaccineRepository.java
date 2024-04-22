package ru.kotik.calendar.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.Vaccine;


@Repository
public interface VaccineRepository extends JpaRepository<Vaccine, Integer>, JpaSpecificationExecutor<Vaccine> {

    Vaccine getVaccinesById(int id);
}

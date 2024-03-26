package ru.kotik.calendar.repositories;

import jakarta.persistence.criteria.CriteriaBuilder;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.VaccineComponent;

import java.util.List;
import java.util.UUID;

@Repository
public interface VaccineComponentRepository extends JpaRepository<VaccineComponent, Integer> {

    List<VaccineComponent> getVaccineComponentsByVaccineId(int id);

    VaccineComponent getVaccineComponentById(int id);
}

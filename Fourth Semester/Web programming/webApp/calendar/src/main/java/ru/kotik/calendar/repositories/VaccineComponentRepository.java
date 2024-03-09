package ru.kotik.calendar.repositories;

import jakarta.persistence.criteria.CriteriaBuilder;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.VaccineComponent;

@Repository
public interface VaccineComponentRepository extends JpaRepository<VaccineComponent, Integer> {
}

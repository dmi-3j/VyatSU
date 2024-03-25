package ru.kotik.calendar.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.CompleteVaccineComponent;

@Repository
public interface CompleteComponentsRepository extends JpaRepository<CompleteVaccineComponent, Integer>, JpaSpecificationExecutor<CompleteVaccineComponent> {
}

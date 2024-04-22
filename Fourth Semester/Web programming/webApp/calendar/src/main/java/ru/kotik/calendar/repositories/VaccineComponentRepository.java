package ru.kotik.calendar.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.VaccineComponent;

import java.util.List;


@Repository
public interface VaccineComponentRepository extends JpaRepository<VaccineComponent, Integer> {

    List<VaccineComponent> getVaccineComponentsByVaccineId(int id);

    VaccineComponent getVaccineComponentById(int id);
}

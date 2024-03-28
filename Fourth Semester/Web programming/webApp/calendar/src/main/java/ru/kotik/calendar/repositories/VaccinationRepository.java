package ru.kotik.calendar.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.entities.Vaccination;

import java.util.List;

@Repository
public interface VaccinationRepository extends JpaRepository<Vaccination, Integer>, JpaSpecificationExecutor<Vaccination> {

    List<Vaccination> getVaccinationsByUser(User user);
}

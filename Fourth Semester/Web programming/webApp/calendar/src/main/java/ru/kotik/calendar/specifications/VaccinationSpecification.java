package ru.kotik.calendar.specifications;

import jakarta.persistence.criteria.Join;
import jakarta.persistence.criteria.Predicate;
import org.springframework.data.jpa.domain.Specification;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.entities.Vaccination;
import ru.kotik.calendar.entities.Vaccine;

import java.util.ArrayList;
import java.util.List;

public class VaccinationSpecification {
    public static Specification<Vaccination> hasUserAndSerial(User user, String serial) {
        return (root, query, criteriaBuilder) -> {
            if (user == null && (serial == null || serial.isBlank())) {
                return criteriaBuilder.conjunction();
            }
            List<Predicate> predicates = new ArrayList<>();
            if (user != null) {
                predicates.add(criteriaBuilder.equal(root.get("user"), user));
            }
            if (serial != null && !serial.isBlank()) {
                predicates.add(criteriaBuilder.like(criteriaBuilder.lower(root.get("serial")), "%" + serial.toLowerCase() + "%"));
            }
            return criteriaBuilder.and(predicates.toArray(new Predicate[0]));
        };
    }

    public static Specification<Vaccination> hasUserAndVaccineName(User user, String vaccineName) {
        return (root, query, criteriaBuilder) -> {
            if (user == null && (vaccineName == null || vaccineName.isBlank())) {
                return criteriaBuilder.conjunction();
            }
            List<Predicate> predicates = new ArrayList<>();
            if (user != null) {
                predicates.add(criteriaBuilder.equal(root.get("user"), user));
            }
            if (vaccineName != null && !vaccineName.isBlank()) {
                Join<Vaccination, Vaccine> vaccineJoin = root.join("vaccine");
                predicates.add(criteriaBuilder.like(criteriaBuilder.lower(vaccineJoin.get("vaccineName")), "%" + vaccineName.toLowerCase() + "%"));
            }
            return criteriaBuilder.and(predicates.toArray(new Predicate[0]));
        };
    }
}

package ru.kotik.calendar.specifications;

import org.springframework.data.jpa.domain.Specification;
import ru.kotik.calendar.entities.Vaccine;

public class VaccineSpecification {

    public static Specification<Vaccine> hasName(String name) {
        return ((root, query, criteriaBuilder) -> {
            if (name == null || name.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(criteriaBuilder.lower(root.get("vaccineName")), "%" + name.toLowerCase() + "%");
        });
    }

    public static Specification<Vaccine> hasCountry(String country) {
        return ((root, query, criteriaBuilder) -> {
            if (country == null || country.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(criteriaBuilder.lower(root.get("manufactorCountry")), "%" + country.toLowerCase() + "%");
        });
    }

    public static Specification<Vaccine> hasValidPeriod(String valid) {
        return ((root, query, criteriaBuilder) -> {
            if (valid == null || valid.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(criteriaBuilder.lower(root.get("validPeriod")), "%" + valid.toLowerCase() + "%");
        });
    }

}

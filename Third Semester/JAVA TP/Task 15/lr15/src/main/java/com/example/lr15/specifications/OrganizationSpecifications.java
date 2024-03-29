package com.example.lr15.specifications;

import com.example.lr15.entities.MedicalOrganization;
import org.springframework.data.jpa.domain.Specification;


public class OrganizationSpecifications {
    public static Specification<MedicalOrganization> hasName(String name) {
        return ((root, query, criteriaBuilder) -> {
            if (name == null || name.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(
                    criteriaBuilder.lower(root.get("name")), "%" + name.toLowerCase() + "%");
        });
    }

    public static Specification<MedicalOrganization> hasAddress(String address) {
        return ((root, query, criteriaBuilder) -> {
            if (address == null || address.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(
                    criteriaBuilder.lower(root.get("address")), "%" + address.toLowerCase() + "%");
        });
    }
    public static Specification<MedicalOrganization> hasTimeOfWork(Integer openingTime) {
        return ((root, query, criteriaBuilder) -> {
            if (openingTime == null) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.and(
                    criteriaBuilder.lessThanOrEqualTo(root.get("openingtime").as(Integer.class), openingTime),
                    criteriaBuilder.greaterThan(root.get("closingtime").as(Integer.class), openingTime)
            );
        });
    }
}

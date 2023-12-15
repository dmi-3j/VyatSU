package com.example.lr15.Specifications;

import com.example.lr15.entities.MedicalOrganization;
import jakarta.persistence.criteria.CriteriaBuilder;
import jakarta.persistence.criteria.Expression;
import jakarta.persistence.criteria.Predicate;
import org.springframework.data.jpa.domain.Specification;

import java.util.ArrayList;
import java.util.List;

public class OrganizationSpecifications {
    public static Specification<MedicalOrganization> hasName(String name) {
        return ((root, query, criteriaBuilder) -> {
            if (name == null || name.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(root.get("name"), "%" + name + "%");
        });
    }

    public static Specification<MedicalOrganization> hasAddress(String address) {
        return ((root, query, criteriaBuilder) -> {
            if (address == null || address.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(root.get("address"), "%" + address + "%");
        });
    }

    public static Specification<MedicalOrganization> hasTimeOfWork(String timeOfWork) {
        return ((root, query, criteriaBuilder) -> {
            if (timeOfWork == null || timeOfWork.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            String test = String.valueOf(root.get("timeOfWork").as(String.class).toString());
            return criteriaBuilder.equal(root.get("timeOfWork"), timeOfWork);
        });
    }
}

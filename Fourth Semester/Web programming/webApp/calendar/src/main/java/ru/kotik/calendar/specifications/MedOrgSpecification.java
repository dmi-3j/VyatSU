package ru.kotik.calendar.specifications;

import org.springframework.data.jpa.domain.Specification;
import ru.kotik.calendar.entities.MedicalOrganization;

public class MedOrgSpecification {
    public static Specification<MedicalOrganization> hasName(String name) {
        return ((root, query, criteriaBuilder) -> {
            if (name == null || name.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(criteriaBuilder.lower(root.get("organizationName")), "%" + name.toLowerCase() + "%");
        });
    }

    public static Specification<MedicalOrganization> hasAddress(String address) {
        return ((root, query, criteriaBuilder) -> {
            if (address == null || address.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(criteriaBuilder.lower(root.get("address")), "%" + address.toLowerCase() + "%");
        });
    }

    public static Specification<MedicalOrganization> hasPhone(String phone) {
        return ((root, query, criteriaBuilder) -> {
            if (phone == null || phone.isBlank()) {
                return criteriaBuilder.conjunction();
            }
            return criteriaBuilder.like(root.get("phoneNumber"), "%" + phone + "%");
        });
    }
}

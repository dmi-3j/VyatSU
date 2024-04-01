package ru.kotik.calendar.specifications;

import jakarta.persistence.criteria.Predicate;
import org.springframework.data.jpa.domain.Specification;
import ru.kotik.calendar.entities.User;

public class UserSpecification {

    public static Specification<User> hasLastName(String lastname) {
        return ((root, query, criteriaBuilder) -> {
            Predicate predicate = criteriaBuilder.conjunction();
            if (lastname == null || lastname.isBlank()) {
                return criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_USER"));
            }
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.like(criteriaBuilder.lower(root.get("lastname")), "%" + lastname.toLowerCase() + "%"));
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_USER"));
            return predicate;
        });
    }

    public static Specification<User> hasFirstName(String firstname) {
        return ((root, query, criteriaBuilder) -> {
            Predicate predicate = criteriaBuilder.conjunction();
            if (firstname == null || firstname.isBlank()) {
                return criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_USER"));
            }
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.like(criteriaBuilder.lower(root.get("firstname")), "%" + firstname.toLowerCase() + "%"));
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_USER"));
            return predicate;

        });
    }

    public static Specification<User> hasInsNum(String insnum) {
        return ((root, query, criteriaBuilder) -> {
            Predicate predicate = criteriaBuilder.conjunction();
            if (insnum == null || insnum.isBlank()) {
                return criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_USER"));
            }
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.like(root.get("inshurancenumber"), "%" + insnum + "%"));
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_USER"));
            return predicate;
        });
    }
}

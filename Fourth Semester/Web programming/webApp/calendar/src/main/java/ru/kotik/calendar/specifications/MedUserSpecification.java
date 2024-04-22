package ru.kotik.calendar.specifications;

import jakarta.persistence.criteria.Predicate;
import org.springframework.data.jpa.domain.Specification;
import ru.kotik.calendar.entities.User;

public class MedUserSpecification {

    public static Specification<User> hasLastName(String lastname) {
        return ((root, query, criteriaBuilder) -> {
            Predicate predicate = criteriaBuilder.conjunction();
            if (lastname == null || lastname.isBlank()) {
                return criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_MED"));
            }
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.like(root.get("lastname"), "%" + lastname + "%"));
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_MED"));
            return predicate;
        });
    }

    public static Specification<User> hasFirstName(String firstname) {
        return ((root, query, criteriaBuilder) -> {
            Predicate predicate = criteriaBuilder.conjunction();
            if (firstname == null || firstname.isBlank()) {
                return criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_MED"));
            }
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.like(root.get("firstname"), "%" + firstname + "%"));
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_MED"));
            return predicate;
        });
    }

    public static Specification<User> hasUserName(String username) {
        return ((root, query, criteriaBuilder) -> {
            Predicate predicate = criteriaBuilder.conjunction();
            if (username == null || username.isBlank()) {
                return criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_MED"));
            }
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.like(root.get("username"), "%" + username + "%"));
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_MED"));
            return predicate;
        });
    }

    public static Specification<User> hasPhone(String phone) {
        return ((root, query, criteriaBuilder) -> {
            Predicate predicate = criteriaBuilder.conjunction();
            if (phone == null || phone.isBlank()) {
                return criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_MED"));
            }
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.like(root.get("phonenumber"), "%" + phone + "%"));
            predicate = criteriaBuilder.and(predicate, criteriaBuilder.equal(root.join("authority").get("authority"), "ROLE_MED"));
            return predicate;
        });
    }
}

package ru.kotik.calendar.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.User;

import java.util.List;

@Repository
public interface UserRepository extends JpaRepository<User, Integer>, JpaSpecificationExecutor<User> {
    User findByusername(String username);

    List<User> findUsersByAuthority_Authority(String authority);

    boolean existsByUsername(String username);

    boolean existsByInshurancenumber(String insuranceNumber);
}

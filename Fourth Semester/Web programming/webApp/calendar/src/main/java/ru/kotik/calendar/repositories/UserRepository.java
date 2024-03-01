package ru.kotik.calendar.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.User;

@Repository
public interface UserRepository extends JpaRepository<User, Integer> {
    User findByusername(String username);
}

package ru.kotik.calendar.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import ru.kotik.calendar.entities.Reaction;

@Repository
public interface ReactionRepository extends JpaRepository<Reaction, Integer> {
    Reaction getReactionById(int id);
}

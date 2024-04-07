package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.Reaction;
import ru.kotik.calendar.entities.Vaccination;
import ru.kotik.calendar.repositories.ReactionRepository;

import java.util.Date;

@Service
public class ReactionService {

    @Autowired
    private ReactionRepository reactionRepository;

    public void deleteReaction(Reaction reaction) {
        reactionRepository.delete(reaction);
    }

    public Reaction getById(int id) {
        return reactionRepository.getReactionById(id);
    }

    public void saveReaction(Vaccination vaccination, String text) {
        Reaction reaction = new Reaction();
        reaction.setTextOfReaction(text);
        reaction.setVaccination(vaccination);
        reaction.setDateofreaction(new Date());
        reactionRepository.save(reaction);
    }
}

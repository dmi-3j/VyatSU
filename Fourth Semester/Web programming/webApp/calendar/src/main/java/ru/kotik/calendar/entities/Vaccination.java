package ru.kotik.calendar.entities;

import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;
import java.util.UUID;

@Entity
@Data
@NoArgsConstructor
@Table(name = "vaccinations")
public class Vaccination {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    private String serial;

    @ManyToOne
    @JoinColumn(name = "vaccine_id")
    private Vaccine vaccine;

    @OneToMany(mappedBy = "vaccination", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<CompleteVaccineComponent> completeComponents;

    @ManyToOne
    @JoinColumn(name = "username")
    private User user;

    @OneToMany(mappedBy = "vaccination", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<Reaction> reactions;

    @Override
    public String toString() {
        return "Vaccination{" +
                "id=" + id +
                ", serial='" + serial + '\'' +
                '}';
    }
}

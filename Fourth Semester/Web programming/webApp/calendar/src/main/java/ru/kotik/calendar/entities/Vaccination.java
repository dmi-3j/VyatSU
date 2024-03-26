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

    private boolean flagisdone;


    @ManyToOne
    @JoinColumn(name = "vaccine_id") // имя столбца в таблице vaccinations, который ссылается на таблицу vaccines
    private Vaccine vaccine;

    @OneToMany(mappedBy = "vaccination", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<CompleteVaccineComponent> completeComponents;

}

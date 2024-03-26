package ru.kotik.calendar.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;


@NoArgsConstructor
@Data
@Entity
@Table(name = "vaccinecomponents")
public class VaccineComponent {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    private String componentName;

    private String structure;

    private String type;

    private String intervalOfComponent;

    @JsonIgnore
    @ManyToOne(fetch = FetchType.LAZY)
    private Vaccine vaccine;
}

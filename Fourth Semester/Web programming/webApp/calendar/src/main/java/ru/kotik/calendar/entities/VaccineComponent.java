package ru.kotik.calendar.entities;

import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@NoArgsConstructor
@Data
@Entity
@Table(name = "vaccinecomponents")
public class VaccineComponent {

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private UUID id;

    private String componentName;

    private String structure;

    private String type;

    private String intervalOfComponent;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "vaccine_id")
    private Vaccine vaccine;
}

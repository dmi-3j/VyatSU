package ru.kotik.calendar.entities;

import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;


@NoArgsConstructor
@Data
@Entity
@Table(name = "medicalorganization")
public class MedicalOrganization {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    private String organizationName;

    private String address;

    private String phoneNumber;

}

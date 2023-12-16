package com.example.lr15.entities;


import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@Entity
@Table(name = "authorities")
public class Authority {

    @Id
    @ManyToOne
    @JoinColumn(name = "username",
    foreignKey = @ForeignKey(name = "username"))
    private User user;

    private String username;
    private String authority;

}

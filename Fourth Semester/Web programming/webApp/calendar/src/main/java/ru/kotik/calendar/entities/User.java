package ru.kotik.calendar.entities;

import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.format.annotation.DateTimeFormat;

import java.util.Date;

@Data
@NoArgsConstructor
@Entity
@Table(name = "users")
public class User {

    @Id
    private String username;

    private String password;

    private String firstname;
    private String lastname;
    private String middlename;

    @DateTimeFormat(pattern = "yyyy-MM-dd")
    private Date dateofbirth;
    private String phonenumber;
    private String address;
    private String inshurancenumber;

    private Boolean enabled;
    private String photopath;

    @OneToOne(mappedBy = "user", cascade = CascadeType.ALL)
    private Authority authority;

}

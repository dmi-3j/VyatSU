package org.example;

import javax.persistence.*;
import java.sql.Date;
import java.util.Collection;
import java.util.List;
import java.util.Objects;

@Entity
@Table(name = "child")
public class Child {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "childid")
    private int childid;
    @Column(name = "firstname")
    private String firstname;

    @Column(name = "lastname")
    private String lastname;

    @Column(name = "middlename")
    private String middlename;

    @Column(name = "dateofbirth")
    private Date dateofbirth;

    @Column(name = "phonenumber")
    private String phonenumber;

    @ManyToOne
    @JoinColumn(name = "userid")
    private UserEnt parent;

    public Child() {
    }

    public Child(String firstname, String lastname, String middlename, Date dateofbirth, String phonenumber) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.middlename = middlename;
        this.dateofbirth = dateofbirth;
        this.phonenumber = phonenumber;
    }

//    public void setUsers(UserEnt user) {
//        users.add(user);
//    }

    public int getChildid() {
        return childid;
    }

    public void setChildid(int childid) {
        this.childid = childid;
    }

    public String getFirstname() {
        return firstname;
    }

    public void setFirstname(String firstname) {
        this.firstname = firstname;
    }

    public String getLastname() {
        return lastname;
    }

    public void setLastname(String lastname) {
        this.lastname = lastname;
    }

    public String getMiddlename() {
        return middlename;
    }

    public void setMiddlename(String middlename) {
        this.middlename = middlename;
    }

    public Date getDateofbirth() {
        return dateofbirth;
    }

    public void setDateofbirth(Date dateofbirth) {
        this.dateofbirth = dateofbirth;
    }

    public String getPhonenumber() {
        return phonenumber;
    }

    public void setPhonenumber(String phonenumber) {
        this.phonenumber = phonenumber;
    }

//    public List<UserEnt> getUsers() {
//        return users;
//    }


    public UserEnt getParent() {
        return parent;
    }

    public void setParent(UserEnt parent) {
        this.parent = parent;
    }
}

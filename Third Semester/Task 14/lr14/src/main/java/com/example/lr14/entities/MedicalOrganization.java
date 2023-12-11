package com.example.lr14.entities;


import jakarta.persistence.*;

@Entity
@Table(name = "medicalorganization")
public class MedicalOrganization {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @Column(name = "organizationname")
    private String name;

    @Column(name = "address")
    private String address;

    @Column(name = "phonenumber")
    private String phone;

    @Column(name = "worktime")
    private String timeOfWork;

    public MedicalOrganization() {
    }

    public MedicalOrganization(Integer id, String name, String address, String phone, String timeOfWork) {
        this.id = id;
        this.name = name;
        this.address = address;
        this.phone = phone;
        this.timeOfWork = timeOfWork;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getTimeOfWork() {
        return timeOfWork;
    }

    public void setTimeOfWork(String timeOfWork) {
        this.timeOfWork = timeOfWork;
    }
}

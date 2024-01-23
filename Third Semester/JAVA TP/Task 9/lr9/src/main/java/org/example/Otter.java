package org.example;

@Table(title = "OTTER12")
public class Otter {

    public enum woolLenght {
        LOW, MEDIUM, HIGH;
        public String getWoolLenght() {
            return this.toString();
        }
    }

   // @Column
    private String name;

    @Column
    private int age;

    @Column
    private int maxRunDistance;

    @Column
    private woolLenght woolLenght;

    public Otter(String name, int age, int maxRunDistance, woolLenght woolLenght) {
        this.name = name;
        this.age = age;
        this.maxRunDistance = maxRunDistance;
        this.woolLenght = woolLenght;
    }


}

package org.example.animals;

public class Hare extends Inhabbitans{
    public static int count;
    public Hare(String name, int age, int maxRunDistance, int maxSwimDistance) {
        super(name, "Заяц",age, maxRunDistance, maxSwimDistance);
        count++;
    }
}

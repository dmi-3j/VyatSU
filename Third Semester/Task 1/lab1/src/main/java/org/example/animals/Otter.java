package org.example.animals;

public class Otter extends Inhabbitans{
    public static int count;
    public Otter(String name, int age, int maxRunDistance, int maxSwimDistance) {
        super(name,"Выдра", age, maxRunDistance, maxSwimDistance);
        count++;
    }
}

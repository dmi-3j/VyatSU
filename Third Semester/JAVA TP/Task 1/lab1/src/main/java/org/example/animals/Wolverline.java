package org.example.animals;

public class Wolverline extends Inhabbitans{
    public static int count;
    public Wolverline(String name, int age, int maxRunDistance, int maxSwimDistance) {
        super(name,"Росомаха", age, maxRunDistance, maxSwimDistance);
        count++;
    }
}

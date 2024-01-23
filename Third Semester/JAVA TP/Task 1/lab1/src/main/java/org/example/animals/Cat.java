package org.example.animals;

public class Cat extends Animal {
    public static int count;
    public Cat(String name, int age, int maxRunDistanse, int maxSwimDistnce) {
        super(name,"Кот", age, maxRunDistanse, 0);
        count ++;
    }

}

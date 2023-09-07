package org.example;

import org.example.animals.*;

public class Main {
    public static void main(String[] args) {
        System.out.println("Hello world!");


        Animal[] animals = {
                new Cat("Barsik", 5, 200, 0),
                new Dog("Bobik", 3, 500, 10),
                new Tiger("Alexey", 8, 150, 50),
                new Tiger("Gosha", 4, 150, 50),
                new Hare("Бакс", 5, 400, 0),
                new Otter("Марлин", 3, 100, 0),
                new Wolverline("Логан", 6, 50, 0)
        };
        for (Animal a : animals) {
            a.run(110);
            a.swim(200);
        }

        System.out.println("Количество котов " + Cat.count);
        System.out.println("Количество собак " + Dog.count);
        System.out.println("Количество тигров " + Tiger.count);


        System.out.println("Рацион зайца. " + ((Inhabbitans) animals[4]).benefit());
        System.out.println("Рацион выдры. " + ((Inhabbitans) animals[5]).benefit());
        System.out.println("Рацион росомахи. " + ((Inhabbitans) animals[6]).benefit());

    }
}
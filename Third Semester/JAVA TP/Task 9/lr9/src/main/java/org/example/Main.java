package org.example;


public class Main {
    public static void main(String[] args) throws Exception {
        Otter otter = new Otter("Barsik", 12, 200, Otter.woolLenght.HIGH);
        Otter otter2 = new Otter("Murzik", 11, 234, Otter.woolLenght.LOW);
        Otter otter3 = new Otter("Vasya", 3, 443, Otter.woolLenght.MEDIUM);
        AnnotationProcessor.createTable(otter);
        AnnotationProcessor.insertIntoTable(otter);
        AnnotationProcessor.insertIntoTable(otter2);
        AnnotationProcessor.insertIntoTable(otter3);
    }
}
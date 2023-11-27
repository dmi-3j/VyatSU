package org.example;

public class Product {
    final private int id;
    private final String title;
    final private int cost;

    public Product(int id, String title, int cost) {
        this.id = id;
        this.title = title;
        this.cost = cost;
    }
    public String printInfo(){
        return "Id Товара: " + id + ", Название: " + title + ", Стоимость: " + cost;
    }
    public String getTitle() {
        return title;
    }
    public int getCost() {
        return cost;
    }
}
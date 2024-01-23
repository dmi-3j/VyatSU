package org.example;

public class Product {
    private final String name;
    private final int quantity;
    private final int price;
    public Country country;

    public enum Country{
        RUSSIA, INDIA, CHINA
    }
    public String getName() {
        return name;
    }

    public int getPrice() {
        return price;
    }

    public int getQuantity() {
        return quantity;
    }

    public Product(String name, int quantity, int price, Country country) {
        this.name = name;
        this.quantity = quantity;
        this.price = price;
        this.country = country;
    }
}
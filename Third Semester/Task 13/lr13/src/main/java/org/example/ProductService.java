package org.example;

import org.springframework.stereotype.Component;
import javax.annotation.PostConstruct;
import java.util.ArrayList;
import java.util.Random;

@Component
public class ProductService {
    private ArrayList<Product> assortment;

    @PostConstruct
    public void generateListOfProducts() {
        Random cost = new Random();
        assortment = new ArrayList<>();
        for (int i = 1; i < 11; i++) {
            assortment.add(new Product(i, "Product #" + i, cost.nextInt(500)+ 100));
        }
    }
    public void printAll() {
        System.out.println("Ассортимент товаров:");
        for (Product p : assortment) {
            System.out.println(p.printInfo());
        }
    }
    public Product findByTitle(String title) {
        for (Product product : assortment) {
            if (product.getTitle().equals(title)) {
                return product;
            }
        }
        return null;
    }
}
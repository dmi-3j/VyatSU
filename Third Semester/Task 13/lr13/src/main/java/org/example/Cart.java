package org.example;

import org.springframework.stereotype.Component;
import java.util.ArrayList;

@Component
public class Cart {
    public ArrayList<Product> cart = new ArrayList<>();
    public void addToCart(Product product) {
        if (product == null) {
            System.out.println("Такого товара нет в ассортименте");
            return;
        }
        cart.add(product);
        System.out.println(product.getTitle() + " добавлен в корзину");
    }
}
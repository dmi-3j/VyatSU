package org.example;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class OrderService {
    @Autowired
    Cart cart;

    public void order() {
        int totalPrice = 0;
        System.out.println("Ваш заказ: ");
        for (Product p: cart.cart) {
            totalPrice += p.getCost();
            System.out.println(p.printInfo());
        }
        System.out.println("Итоговая стоимость: " + totalPrice);
    }
}

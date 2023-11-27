package org.example;

import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

public class Main {
    public static void main(String[] args) {
        ApplicationContext context = new AnnotationConfigApplicationContext(AppConfig.class);
        ProductService service = context.getBean("productService", ProductService.class);
        service.printAll();
        System.out.println("===========");
        Cart cart = context.getBean("cart", Cart.class);
        cart.addToCart(service.findByTitle("Product #7"));
        cart.addToCart(service.findByTitle("Product #2"));
        System.out.println("===========");
        OrderService order = context.getBean("orderService", OrderService.class);
        order.order();
    }
}
package org.example;

import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

public class Main {
    public static void main(String[] args) {
        ApplicationContext context = new AnnotationConfigApplicationContext(AppConfig.class);
        TravelService service = context.getBean("travelService", TravelService.class);
        service.printAll();
        System.out.println("===========");
        //service.order("2023-11-28", "Иннополис");
        service.order("2023-11-28", "Киров");
    }
}
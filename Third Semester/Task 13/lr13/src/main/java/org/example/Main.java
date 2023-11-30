package org.example;

import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

public class Main {
    public static void main(String[] args) {
        ApplicationContext context = new AnnotationConfigApplicationContext(AppConfig.class);
        TravelService service = context.getBean("travelService", TravelService.class);
        service.printAll();
        System.out.println("===========");
        service.addToRequest("2023-11-28", "Иннополис");
        service.addToRequest("2023-11-30",  "Самара");
        service.order();
        System.out.println("===========");
        service.sendEmail("test@mail.ru");
    }
}
package org.example;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class MileService {
    @Autowired
    TravelersCard travelersCard;
    public void sendEmail(String email) {
        if (!travelersCard.card.isEmpty()) {
            StringBuilder message = new StringBuilder();
            for (Trip trip : travelersCard.card) {
                message.append(trip.printInfo()).append("\n");
            }
            System.out.println("Сообщение: \nСписок ваших туров: \n" + message + "отправлено на " + email);
        }
        else System.out.println("В вашей карте нет туров");
    }
}

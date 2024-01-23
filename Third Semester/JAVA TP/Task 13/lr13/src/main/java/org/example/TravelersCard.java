package org.example;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import java.util.ArrayList;

@Component
public class TravelersCard {
    public ArrayList<Trip> card = new ArrayList<>();

    @Autowired
    Request request;
    public boolean addToCard() {
        if(!request.tripList.isEmpty()) {
            card.addAll(request.tripList);
            for (Trip trip : card) System.out.println("Тур " + trip.getDeparture() + " - " + trip.getArrival() + " добавлен в карту путешественника");
            System.out.println("Общее количество туров: " + card.size());
            return true;
        }
        else {
            System.out.println("В заявке нет туров");
            return false;
        }
    }
}
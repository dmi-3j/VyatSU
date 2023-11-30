package org.example;

import org.springframework.stereotype.Component;
import java.util.ArrayList;

@Component
public class TravelersCard {
    public ArrayList<Trip> card = new ArrayList<>();
    public void addToCard(Trip trip) {
        if (trip == null) {
            System.out.println("Такого тура нет в программе");
            return;
        }
        card.add(trip);
        System.out.println("Тур " + trip.getDeparture() + " - " + trip.getArrival() + " добавлен в карту путешественника");
    }
}
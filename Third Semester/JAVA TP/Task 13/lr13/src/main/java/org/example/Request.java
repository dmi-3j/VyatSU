package org.example;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class Request {

    public List<Trip> tripList = new ArrayList<>();

    @Autowired
    private TravelService travelService;

    public boolean add(String date,String arrival) {
        Trip trip = travelService.findByDate(date);
        if (trip!= null && trip.getArrival().equals(arrival) && trip.getDate().equals(date)) {
            System.out.println("Дата заявки:  2023-11-30");
            tripList.add(trip);
            System.out.println("Тур " + trip.getDeparture() + " - " + trip.getArrival() + " добавлен в заявку");
            return true;
        }
        else {
            System.out.println("Тур на такую дату или на такое направление не найден");
            return false;
        }
    }
}

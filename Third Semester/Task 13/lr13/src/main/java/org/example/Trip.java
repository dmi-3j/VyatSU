package org.example;


public class Trip {
    final private int id;
    private final String date;

    private final String departure;
    private final String arrival;

    public Trip(int id, String date, String departure, String arrival) {
        this.id = id;
        this.date = date;
        this.departure = departure;
        this.arrival = arrival;
    }

    public String printInfo(){
        return "Id Тура: " + id + ", Место отправления: " + departure + ", Место прибытия: " + arrival + " Дата тура: " + date;
    }
    public String getDeparture() {
        return departure;
    }

    public String getDate() {
        return date;
    }
    public String getArrival() {
        return arrival;
    }
}
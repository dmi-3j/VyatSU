package org.example;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.CyclicBarrier;

public class Car implements Runnable {
    private static int CARS_COUNT;
    private static boolean winnerFound;
    private static final Car[] winners = new Car[3];
    private  static final Object lock = new Object();
//    private static  String winner;

    static {
        CARS_COUNT = 0;
    }

    private CyclicBarrier cb;
    private CountDownLatch cdl;
    private Race race;
    private int speed;
    private String name;

    public String getName() {
        return name;
    }

    public int getSpeed() {
        return speed;
    }

    public Car(Race race, int speed, CyclicBarrier cb, CountDownLatch cdl) {
        this.race = race;
        this.speed = speed;
        CARS_COUNT++;
        this.name = "Участник #" + CARS_COUNT;
        this.cb = cb;
        this.cdl = cdl;
    }

    @Override
    public void run() {
        try {
            System.out.println(this.name + " готовится");
            Thread.sleep(500 + (int) (Math.random() * 800));
            System.out.println(this.name + " готов");
            cb.await();
            for (int i = 0; i < race.getStages().size(); i++) {
                race.getStages().get(i).go(this);
            }
            cdl.countDown();
            CheckWin(this);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
private static void CheckWin(Car car) {
    synchronized (lock) {
        if (!winnerFound) {
            for (int i = 0; i < 3; i++) {
                if (winners[i] == null) {
                    winners[i] = car;
                    break;
                }
            }
            if (winners[2] != null) {
                winnerFound = true;
            }
        }
    }
}
public static void printWinners() {
    System.out.println("ПОБЕДИТЕЛИ");
    for (int i = 0; i < 3; i++) {
        System.out.println((i+1) + " МЕСТО: " + winners[i].getName());
    }
}
}

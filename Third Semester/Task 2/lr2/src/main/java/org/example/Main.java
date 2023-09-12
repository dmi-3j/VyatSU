package org.example;

public class Main {

    public static void main(String[] args) {
       Participant[] participants = {
               new Human(2, 350, "Jesus"),
               new Robot(7, 900, "Chpher"),
               new Cat(1, 100, "Fet"),
               new Robot(3,400,"CyberBull"),
               new Robot(5, 250, "Bill")
       };
      Challenge[] challenges = {
              new RunningRoad(RoadLenght.LOW),
              //new RunningRoad(RoadLenght.HIGH),
              new RunningRoad(RoadLenght.HIGH),
              new RunningRoad(RoadLenght.HIGH),
              new Wall(WallHeight.LOW),

              new RunningRoad(RoadLenght.MEDIUM),
              new Wall(WallHeight.HIGH),
              new RunningRoad(RoadLenght.HIGH),
              new Wall(WallHeight.MEDIUM)
      };

      for(Participant p: participants) {
          for (Challenge c: challenges) {
              if (!c.isCan(p)) break;
          }
      }
    }
}
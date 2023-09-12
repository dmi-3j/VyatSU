package org.example;

public class Robot implements Participant{
    int maxHeight;
    int maxLenght;
    String name;
    public static int superRunCount = 3;

    public Robot(int maxHeight, int maxLenght, String name) {
        this.maxHeight = maxHeight;
        this.maxLenght = maxLenght;
        this.name = name;
    }

    @Override
    public boolean run(int dist) {
        if (dist <= maxLenght) {
            System.out.println("Робот " +this.name + " пробежал " + dist + " м");
            return true;
        }
        else if (superRunCount != 0) {
            superRun();
            return true;
        }
        else System.out.println("Робот " +this.name + " не смог пробежать " + dist + " м и выбывает");
        return false;
    }
    @Override
    public boolean jump(int height) {
        if (height<= maxHeight) {
            System.out.println("Робот "+ this.name+ " перепрыгнул " + height  +" м");
            return true;
        }
        else {
            System.out.println("Робот "+ this.name+ " не смог перепрыгнуть " + height  +" м и выбывает");
            return false;
        }
    }

    public void superRun() {
        System.out.println("Робот " + this.name+ " пробежал "+ " с допингом");
        superRunCount --;

    }
}

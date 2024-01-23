package org.example;

public  class Cat implements Participant{
    int maxHeight;
    int maxLenght;
    String name;

    public Cat(int maxHeight, int maxLenght, String name) {
        this.maxHeight = maxHeight;
        this.maxLenght = maxLenght;
        this.name = name;
    }

    @Override
    public boolean run(int dist) {
        if (dist <= maxLenght) {
            System.out.println("Кот " +this.name + " пробежал " + dist + " м");
            return true;
        }
        else {System.out.println("Кот " +this.name + " не смог пробежать " + dist + " м и выбывает");
        return false;}

    }
    @Override
    public boolean jump(int height) {
        if (height<= maxHeight) {
            System.out.println("Кот "+ this.name+ " перепрыгнул " + height  +" м");
            return true;
        }
        else {
            System.out.println("Кот "+ this.name+ " не смог перепрыгнуть " + height  +" м и выбывает");
            return false;
        }
    }


}

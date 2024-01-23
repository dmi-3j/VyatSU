package org.example;

import java.util.ArrayList;
import java.util.List;

public class Box<L extends Fruit> {
    public List<L> getList(){
        return list;
    }
    private List<L> list;
    public Box(L obj) {
        list = new ArrayList<>();
        list.add(obj);
    }
    void add(L obj) {
        list.add(obj);
    }
//    void add(Object obj) {
//        list.add((L) obj);
//    }
    void moveTo(Box<L> box) {
        if(!box.getList().equals(list)) {
            box.getList().addAll(list);
            list.clear();
        }
    }
    float getWeight() {
        float weight = 0;
        if (list.isEmpty()) {
            return 0;
        }
        else {
            for (L l : list) {
                weight += l.getWeight();
            }
            return weight;
        }
    }
    boolean compare (Box<?> box){
        return Math.abs(this.getWeight()- box.getWeight()) < 0.0001;
    }
    void printBox() {
        if (list.isEmpty()) {
            System.out.println("Коробка пуста");
        }
        else{
            for (L l : list) {
                System.out.println(l);
            }
        }
    }
}

package org.example;
import java.util.List;
import java.util.Arrays;

public class Main {
    public static void main(String[] args) {
        System.out.println("1 задание");
        Integer[] arr1 = {51, 13, 0, 7,3,16};
        String[] arr2 = {"яблоко", "кошка", "электромобиль","архитектура", "ямб"};
        System.out.println(Arrays.toString(arr1));
        swapElements(arr1, 1,4);
        System.out.println(Arrays.toString(arr1));
        System.out.println(Arrays.toString(arr2));
        swapElements(arr2, 2,3);
        System.out.println(Arrays.toString(arr2));

        System.out.println("2 задание");
        List<String> list = convertToList(arr2);
        System.out.println(list);

        System.out.println("3 задание");
        Box<Apple> appleBox1 = new Box<>(new Apple());
        Box<Orange> orangeBox = new Box<>(new Orange());
        Box<Apple> appleBox2 = new Box<>(new Apple());
        for(int i =0;i<5;i++) {
            orangeBox.add(new Orange());
        }
        for(int i = 0; i< 3;i++) {
            appleBox1.add(new Apple());
        }
        for (int i = 0; i<4;i++){
            appleBox2.add(new Apple());
        }
        System.out.println("\n");
        Box lemonBox = new Box(new Apple());
        lemonBox.add(new Orange());
        lemonBox.add(new Orange());
        lemonBox.add(new Apple());
        lemonBox.add(new Lemon());
        lemonBox.printBox();

        System.out.println("-------");
        lemonBox.moveTo(lemonBox);
        lemonBox.printBox();
        lemonBox.add(new Orange());
        appleBox2.add(new Apple());
        //appleBox2.add(new Orange());
        //appleBox1.moveTo(orangeBox);
    }
    private static <T> void swapElements(T[] array, int index1, int index2) {
        T temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
    private static <V> List<V> convertToList(V[] array){
        return Arrays.asList(array);
    }
}
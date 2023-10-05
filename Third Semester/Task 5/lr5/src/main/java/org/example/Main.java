package org.example;

import java.util.HashMap;

public class Main {
    public static void main(String[] args) {
        String[] arrayWord = {"Авто", "Собака", "Авто", "Холодильник","Очки","Телефон", "Собака", "Магнитофон", "Собака"};
        HashMap<String, Integer> listWord = new HashMap<String, Integer>();
        for (String s: arrayWord) {
            listWord.merge(s, 1, Integer::sum);
        }
        System.out.println(listWord.entrySet());

        System.out.println("=================");
        SynonimDict d = new SynonimDict();
        d.add("Автор", "Составитель");
        d.add("Автор", "Творец");
        d.add("Красивый", "Привлекательный");

        d.add("Прекрасно", "Восхитительно");
        d.add("Прекрасно", "Превосходно");
        d.add("Прекрасно", "Отлично");
        d.add("Прекрасно", "Замечательно");
        d.add("Диплом", "Вода");
        d.add("Код", "Костыли");
        d.add("Код", "Костыли");


        System.out.println(d.get("Прекрасно"));
        System.out.println("=================");
        d.printAll();

    }
}


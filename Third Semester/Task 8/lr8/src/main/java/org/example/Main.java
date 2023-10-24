package org.example;

import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import static java.util.stream.Collectors.*;

public class Main {
    public static void main(String[] args) {
        System.out.println("=== 1 задание ===");
        List<String> list = new ArrayList<>(Arrays.asList("Чайник", "Сковорода", "Роза", "Чайник", "Ночь", "Улица", "Фонарь", "Аптека", "Роза", "Аптека"));
       var stringStream = list.stream()
                .collect(groupingBy(Function.identity(), counting()))
                .entrySet().stream()
                .collect(groupingBy(Map.Entry::getValue, mapping(Map.Entry::getKey, toCollection(TreeSet::new))))
                .entrySet().stream()
                .max(Map.Entry.comparingByKey())
                .map(longTreeSetEntry -> longTreeSetEntry.getValue().stream().limit(2).collect(joining(", ")))
                .orElse("");

        System.out.println(stringStream);


        System.out.println("=== 2 задание ===");
        List<Product> products = new ArrayList<>(Arrays.asList(
                new Product("Marshmallow", 24, 150, Product.Country.CHINA),
                new Product("Waffles", 43, 79, Product.Country.INDIA),
                new Product("Banana", 18, 90, Product.Country.INDIA),
                new Product("Milk", 50, 75, Product.Country.RUSSIA),
                new Product("Kefir", 26, 67, Product.Country.RUSSIA),
                new Product("Waffles2", 300, 999, Product.Country.INDIA)
        ));
        printNExpensive(products, 3);
    }
    public static void printNExpensive(List<Product> products, int n) {
        System.out.println(
                products.stream()
                        .sorted(Comparator.comparingInt(Product::getPrice)
                                .reversed()).limit(n).sorted((Comparator.comparingInt(Product::getQuantity)).reversed()).map(Product::getName)
                        .collect(joining(" , ", n + " самых дорогих продуктов на складе: ", ";")));
    }
}
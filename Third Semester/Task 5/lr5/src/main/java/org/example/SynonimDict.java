package org.example;

import java.util.*;

public class SynonimDict {
    private final Map<String, TreeSet<String>> dict;

    public SynonimDict() {
        dict = new TreeMap<>();
    }
    public void add (String word, String sinonim) {
        dict.computeIfAbsent(word, k -> new TreeSet<>()).add(sinonim);
    }

    public String get(String word) {
        TreeSet<String> sinonims = dict.get(word);
        if (sinonims != null && !sinonims.isEmpty()) {
            return String.join(", ", sinonims);
        } else {
            return "Синонимы не найдены";
        }
    }
    public void printAll() {
        System.out.println(dict.entrySet());
    }
}

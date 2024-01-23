package org.example;

public class MyConsonantsException extends RuntimeException{
    private int i;
    private int j;
    private  String s;
    public MyConsonantsException(int i, int j, String s) {
    super("В массиве обнаружена согласная буква '" + s + "' Номер ячейки: " + (i+1) + " x " + (j+1));
    this.i = i;
    this.j = j;
    this.s = s;
    }
}

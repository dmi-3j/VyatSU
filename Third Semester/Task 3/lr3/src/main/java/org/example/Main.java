package org.example;

public class Main {
    public static void main(String[] args) {
        String[][] array = {
                {"2", "0", "6", "8"},
                {"1", "н", "5", "2"},
                {"9", "1", "щ", "6"},
                {"0", "7", "7", "л"}
        };
        try {
            if (check(array)) System.out.println("Результат: " + sum);
            ;
        } catch (MyArraySizeException |MyArrayDataException e) {
            e.printStackTrace();
        }

    }
    static int sum = 0;
    static int s = 0;
    public static boolean check(String[][] array) throws MyArraySizeException, MyArrayDataException, MyConsonantsException {
        boolean tmp = true;
            for (int i = 0; i < array.length; i++) {
                if (array[i].length != 4) throw new MyArraySizeException("Ваш массив не 4x4");
                else {
                    for (int j = 0; j < array[i].length; j++) {
                        if(array[j].length != 4) throw new MyArraySizeException("Ваш массив не 4x4");
                        try {
                            if (!(array[i][j].matches("(?ui:[бвгджзйклмнпрстфхцчшщ])")))
                            s = Integer.valueOf(array[i][j]);
                            if(array[i][j].length() > 1) throw new MyArrayDataException(i, j, array[i][j]);
                        }
                        catch (NumberFormatException e) {
                            throw new MyArrayDataException(i,j, array[i][j]);
                        }
                    }
                }
            }
            for(int i = 0; i< array.length; i++) {
                for (int j=0; j< array[i].length; j++) {
                    try {
                        sum += Integer.valueOf(array[i][j]);
                    }
                    catch (NumberFormatException e) {
                        try {
                            if (array[i][j].matches("(?ui:[бвгджзйклмнпрстфхцчшщ])"))
                                throw new MyConsonantsException(i, j, array[i][j]);
                        } catch (MyConsonantsException  ee) {
                            ee.printStackTrace();
                            tmp = false;
                        }
                    }
                }
            }
        return tmp;
    }
}
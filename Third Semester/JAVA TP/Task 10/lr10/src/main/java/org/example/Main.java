package org.example;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.HashSet;

public class Main {
    static Connection connection = null;
    static Statement statement = null;
    public static void main(String[] args) throws SQLException {
        connect();

        statement.execute("drop table if exists public.progress;\n" +
                "\n" +
                "drop table if exists public.students;\n" +
                "\n" +
                "drop table if exists public.subjects;");
        statement.execute("CREATE TABLE IF NOT EXISTS students\n" +
                "(id serial NOT NULL PRIMARY KEY,\n" +
                " name varchar(30) NOT NULL,\n" +
                " PassportSerial varchar(4) not null,\n" +
                " PassportNumber varchar(6) not null,\n" +
                " UNIQUE (PassportSerial, PassportNumber)\n" +
                ");");
        statement.execute("CREATE TABLE IF NOT EXISTS subjects\n" +
                "(id serial NOT NULL PRIMARY KEY,\n" +
                " name varchar(50) NOT NULL\n" +
                ");");

        statement.execute("CREATE TABLE IF NOT EXISTS progress\n" +
                "(id serial NOT NULL PRIMARY KEY,\n" +
                " student int NOT NULL REFERENCES students(id) ON DELETE CASCADE,\n" +
                " subject int NOT NULL REFERENCES subjects(id),\n" +
                " mark smallint NOT NULL CHECK(mark BETWEEN 2 and 5)\n" +
                ");");
        statement.execute("INSERT into students (id, name, PassportSerial, PassportNumber)\n" +
                "values\n" +
                "    (1, 'Вася', 3311, 435678),\n" +
                "    (2, 'Коля', 3322, 342345),\n" +
                "    (3, 'Петя', 3333, 123456),\n" +
                "    (4, 'Маша', 3344, 234567),\n" +
                "    (5, 'Даша', 3355, 345678),\n" +
                "    (6, 'Саша', 3366, 456789),\n" +
                "    (7, 'Лена', 3377, 567890),\n" +
                "    (8, 'Катя', 3388, 678901),\n" +
                "    (9, 'Оля', 3399, 789012),\n" +
                "    (10, 'Юля', 3300, 890123);");
        statement.execute("INSERT into subjects (id, name)\n" +
                "values\n" +
                "    (1, 'Математика'),\n" +
                "    (2, 'Русский язык'),\n" +
                "    (3, 'Физика'),\n" +
                "    (4, 'Химия'),\n" +
                "    (5, 'Биология'),\n" +
                "    (6, 'Информатика');");
        statement.execute("INSERT into progress (id, student, subject, mark)\n" +
                "values\n" +
                "    (1, 1, 1, 5),\n" +
                "    (2, 1, 2, 4),\n" +
                "    (3, 1, 3, 5),\n" +
                "    (4, 1, 4, 4),\n" +
                "    (5, 1, 5, 5),\n" +
                "    (6, 1, 6, 4),\n" +
                "    (8, 2, 2, 4),\n" +
                "    (9, 2, 3, 3),\n" +
                "    (10, 2, 4, 4),\n" +
                "    (11, 2, 5, 3),\n" +
                "    (12, 2, 6, 4),\n" +
                "    (13, 3, 1, 5),\n" +
                "    (14, 3, 2, 5),\n" +
                "    (15, 3, 3, 5),\n" +
                "    (17, 3, 5, 5),\n" +
                "    (18, 3, 6, 5),\n" +
                "    (19, 4, 1, 4),\n" +
                "    (20, 4, 2, 4),\n" +
                "    (21, 4, 3, 4),\n" +
                "    (22, 4, 4, 4),\n" +
                "    (24, 4, 6, 4),\n" +
                "    (27, 5, 3, 3),\n" +
                "    (28, 5, 4, 3),\n" +
                "    (29, 5, 5, 3),\n" +
                "    (30, 5, 6, 3),\n" +
                "    (31, 6, 1, 2),\n" +
                "    (32, 6, 2, 2),\n" +
                "    (33, 6, 3, 2),\n" +
                "    (34, 6, 4, 2),\n" +
                "    (35, 6, 5, 2),\n" +
                "    (36, 6, 6, 2);\n");
        System.out.println("Вывести список студентов, сдавших определенный предмет, на оценку выше 3");
        var res = statement.executeQuery("Select s.name, p.Mark, ss.name from Students s\n" +
                "INNER JOIN Progress p\n" +
                "on s.id = p.id\n" +
                "inner join subjects ss\n" +
                "on ss.id = p.id\n" +
                "WHERE p.mark > 3 and ss.name = 'Математика';");
        while (res.next()) {
            String subjName = res.getString(1);
            int mark = res.getInt(2);
            String studName = res.getString(3);
            System.out.println(subjName + " " + mark + " " + studName);
        }
        System.out.println("Посчитать средний бал по определенному предмету");
        var res2 = statement.executeQuery("select avg(p.mark) as \"Средний балл\" from progress p\n" +
                "inner join subjects s on p.subject = s.id\n" +
                "where s.name = 'Математика';");
        while (res2.next()) {
            double avg = res2.getDouble(1);
            System.out.println(avg);
        }
        System.out.println("Посчитать средний балл по определенному студенту");
        var res3 = statement.executeQuery("select avg(p.mark) as \"Средний балл\" from progress p\n" +
                "inner join subjects s on p.subject = s.id\n" +
                "inner join students s2 on p.student = s2.id\n" +
                "where s2.name = 'Даша';");
        while (res3.next()) {
            double avg = res3.getDouble(1);
            System.out.println(avg);
        }
        System.out.println("Найти три премета, которые сдали наибольшее количество студентов");
        var res4 = statement.executeQuery("SELECT count(*), s.name from progress p\n" +
                "inner join subjects s on s.id = p.subject\n" +
                "where p.mark > 2\n" +
                "group by s.name\n" +
                "order by count(*) desc limit 3;");
        while (res4.next()) {
            int cnt = res4.getInt(1);
            String name  =  res4.getString(2);
            System.out.println(cnt + " " + name);
        }
        System.out.println();
        disconnect();


    }
    public static void connect() {

        try {
            Class.forName("org.postgresql.Driver");
            connection = DriverManager.getConnection("jdbc:postgresql://localhost:5432/lab10", "postgres", "1");
            statement = connection.createStatement();
            System.out.println("Connected");



        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void disconnect() {
        try{
            statement.close();
        }
        catch (SQLException e) {
            e.printStackTrace();
        }
        try {
            connection.close();
            System.out.println("Disconnected");
        }
        catch (SQLException ee) {
            ee.printStackTrace();
        }
    }
}
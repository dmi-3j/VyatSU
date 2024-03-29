package org.example;

import java.lang.reflect.Field;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;

public class AnnotationProcessor {

    public static void createTable(Object cl) throws Exception {
        Class<?> clClass = cl.getClass();
        if (!clClass.isAnnotationPresent(Table.class)) {
            throw new Exception("Класс не содержит аннотации @Table");
        }
        Table table = clClass.getAnnotation(Table.class);
        StringBuilder sql = new StringBuilder("CREATE TABLE " + table.title() + " (");
        StringBuilder sqlDEL = new StringBuilder("DROP TABLE IF EXISTS " + table.title() + ";");
        Field[] fields = clClass.getDeclaredFields();
        for (Field field : fields) {
            if (field.isAnnotationPresent(Column.class)) {
                field.setAccessible(true);
                Column column = field.getAnnotation(Column.class);
                sql.append(field.getName()).append(" ");
                if (field.getType() == int.class) {
                    sql.append("INT");
                }
                else if (field.getType() == String.class) {
                    sql.append("TEXT");
                }
                else {
                    sql.append("TEXT");
                }

                sql.append(",");
            }
        }
//        else if (field.getType() == Cat.Breed.class) {
//            sql.append("TEXT");
//        }
        sql.deleteCharAt(sql.length() - 1);
        sql.append(");");
        Connection connection = null;
        try{
//            connection = DriverManager.getConnection("jdbc:sqlite:D:\\TP\\lr9\\lr9.db");

            Class.forName("org.postgresql.Driver");

            // Replace the connection URL with your PostgreSQL connection details
            String url = "jdbc:postgresql://localhost:5432/test";
            String user = "postgres";
            String password = "1";

            // Create the connection
            connection = DriverManager.getConnection(url, user, password);
            if (connection != null) {
                Statement statement = connection.createStatement();
                statement.execute(sqlDEL.toString());
                statement.execute(sql.toString());
            }

        }
        catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            try {
                if (connection != null) connection.close();
            }
            catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
    public static void insertIntoTable(Object cl) {
        Class<?> clClass = cl.getClass();
        if (!clClass.isAnnotationPresent(Table.class)) {
            throw new RuntimeException("Класс не содержит аннотации @Table");
        }
        String tableName = clClass.getAnnotation(Table.class).title();

        Field[] fields = clClass.getDeclaredFields();
        StringBuilder query = new StringBuilder("INSERT INTO " + tableName + " (");
        for (Field field : fields) {
            if (field.isAnnotationPresent(Column.class)) {
                query.append(field.getName()).append(",");
            }
        }
        query.deleteCharAt(query.length() - 1).append(") VALUES (");
        for (Field field : fields) {
            if (field.isAnnotationPresent(Column.class)) {
                field.setAccessible(true);
                try {
                    query.append("'").append(field.get(cl)).append("',");
                }
                catch (IllegalAccessException e) {
                    e.printStackTrace();
                }
            }
        }
        query.deleteCharAt(query.length() - 1).append(")");
        Connection connection = null;
        try{
            connection = DriverManager.getConnection("jdbc:sqlite:D:\\TP\\lr9\\lr9.db");
            Statement statement = connection.createStatement();
            statement.execute(query.toString());
        }
        catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            try {
                if (connection != null) connection.close();
            }
            catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
}

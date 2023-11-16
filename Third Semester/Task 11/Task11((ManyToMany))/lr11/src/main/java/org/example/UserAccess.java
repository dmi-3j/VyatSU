package org.example;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
//import jakarta.persistence.*;
import java.util.*;

public class UserAccess {
    private final SessionFactory sessionFactory;

    public UserAccess(SessionFactory sessionFactory) {
        this.sessionFactory = sessionFactory;
    }

    //insert
    public void addUser(UserEnt user) {
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();
            session.persist(user);
            session.getTransaction().commit();
            session.close();
        }
    }

    public void addChild(Child child) {
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();
            session.persist(child);
            session.close();
        }
    }

    public void setParent(int userId, int childId) {
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();

            UserEnt user = session.get(UserEnt.class, userId);
            Child child = session.get(Child.class, childId);

            if (user != null && child != null) {
                child.getUsers().add(user);
                session.update(user);
                session.update(child);
            }
            session.getTransaction().commit();
            session.close();
        }
    }

    //delete
    public void deleteUser(int userid) {
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();
            UserEnt user = session.find(UserEnt.class, userid);
            if (user != null) {
                session.delete(user);
                System.out.println("Пользователь с id " + userid + " удалён");
            }
            else System.out.println("Пользователя с id " + userid + " не существует или он удалён ранее");
            session.getTransaction().commit();
            session.close();
        }
    }

    //update
    public void changeName(int userId, String newName) {
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();
            UserEnt user = session.find(UserEnt.class, userId);
            if (user != null) {
                user.setFirstname(newName);
                session.update(user);
                System.out.println("Имя пользователя с id " + userId + " изменено на " + newName);
            }
            else {
                System.out.println("Пользователь с id " + userId + " не найден");
            }
            session.getTransaction().commit();
            session.close();
        }
    }
    //select
    public void getChildrenByUserId(int userId) {
        Set<Child> children = new HashSet<>();
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();

            UserEnt user = session.get(UserEnt.class, userId);
            if (user != null) {
                children = user.getChilds();
            }
            List<String> list = new ArrayList<>();
            if (!children.isEmpty()) {
                for (Child c : children) list.add(c.getFirstname());
                System.out.println("[" + user.getFirstname() + " " + list + "]");
            } else if (user != null) {
                System.out.println("[" + user.getFirstname() + " [Нет детей]" + "]");
            }
            else {
                System.out.println("Пользователь с id " + userId + " не найден");
            }
            session.getTransaction().commit();
            session.close();
        }
    }

    public void getParentByChildId(int childId) {
        Set<UserEnt> parents = new HashSet<>();
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();
            Child child = session.get(Child.class, childId);
            if (child != null) parents = child.getUsers();
            List<String> par = new ArrayList<>();
            for (UserEnt c : parents) par.add(c.getFirstname());
            if (!par.isEmpty()) {
                System.out.println("[" + child.getFirstname() + " " + par + "]");
            }
            else if (child != null){
                System.out.println("[" + child.getFirstname() + " [Нет родителей]" + "]");
            }
            else System.out.println("Ребёнок с id " + childId + " не найден");
        }
    }
}
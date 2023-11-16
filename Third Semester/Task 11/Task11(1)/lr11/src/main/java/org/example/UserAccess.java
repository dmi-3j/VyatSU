package org.example;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
//import jakarta.persistence.*;
import javax.persistence.NoResultException;
import javax.persistence.Query;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class UserAccess {
    private final SessionFactory sessionFactory;

    public UserAccess(SessionFactory sessionFactory) {
        this.sessionFactory = sessionFactory;
    }
    //insert
    public void addUser(UserEnt user){
        try(Session session = sessionFactory.openSession()) {
            session.beginTransaction();
            session.persist(user);
            session.getTransaction().commit();
            session.close();
        }
    }
    public void addChild(Child child) {
        try(Session session = sessionFactory.openSession()) {
            session.beginTransaction();
            session.persist(child);
            session.close();
        }
    }

//    public void setParent(UserEnt user, Child child) {
//        try(Session session = sessionFactory.openSession()) {
//            session.beginTransaction();
//            user = session.get(UserEnt.class, user.getUserid());
//            child = session.get(Child.class, child.getChildid());
//            user.getChilds().add(child);
//            child.getUsers().add(user);
//            session.update(user);
//            session.update(child);
//            session.getTransaction().commit();
//            session.close();
//        }
//    }
public void setParent(int userId, int childId) {
    try(Session session = sessionFactory.openSession()) {
        session.beginTransaction();

        UserEnt user = session.get(UserEnt.class, userId);
        Child child = session.get(Child.class, childId);

        if (user != null && child != null) {
            child.setParent(user);
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
            List<Child> children = user.getChilds();
            for (Child c : children) c.setParent(null);
            session.delete(user);
            session.getTransaction().commit();
            session.close();
        }
    }
    //update
    public void changeMame(int userId, String newName) {
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();
            UserEnt user = session.find(UserEnt.class, userId);
            user.setFirstname(newName);
            session.update(user);
            session.getTransaction().commit();
            session.close();
        }
    }
    public void getChildrenByUserId(int userId) {
        List<Child> children = new ArrayList<>();
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();

            UserEnt user = session.get(UserEnt.class, userId);
            if (user != null) {
                children = user.getChilds();
            }
            List<String> list = new ArrayList<>();
            if(!children.isEmpty()) {
                for (Child c : children) list.add(c.getFirstname());
                System.out.println("[" + user.getFirstname() + " " + list + "]");
            }
            else {
                System.out.println("[" + user.getFirstname() + " [Нет детей]" + "]");
            }

            session.getTransaction().commit();
            session.close();
        }
    }
    public void getParentByChildId(int childId) {
        try (Session session = sessionFactory.openSession()) {
            session.beginTransaction();
            Child child = session.get(Child.class, childId);

            if (child != null) {
                try {
                    UserEnt parent;
                    parent = child.getParent();
                    System.out.println("[" + child.getFirstname() + " [" + parent.getFirstname() + "]]");
                } catch (NullPointerException e) {
                    System.out.println("[" + child.getFirstname() + " [Нет родителей]" + "]");
                }
            }
        }
    }



}


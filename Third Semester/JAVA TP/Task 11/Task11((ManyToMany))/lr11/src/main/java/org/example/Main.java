package org.example;

import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;

import java.sql.Date;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Configuration configuration = new Configuration()
                .addAnnotatedClass(UserEnt.class).addAnnotatedClass(Child.class);
        configuration.configure();
        try(SessionFactory sf = configuration.buildSessionFactory()) {
            UserAccess userAccess = new UserAccess(sf);
//           UserEnt user1 = new UserEnt("Эльвира", "Веккер", "Викторовна", Date.valueOf("2002-07-16"), "Попова 21", "+79091329714");
//            userAccess.addUser(user1);
//             Child child1 = new Child("Алексей", "Бондаренко", "Петрович", Date.valueOf("2008-12-16"), "+79531367552");
//            userAccess.addChild(child1);
//         userAccess.setParent(1, 1);
//            UserEnt user2 = new UserEnt("Эльвира2", "Веккер", "Викторовна", Date.valueOf("2002-07-16"), "Попова 21", "+79091329714");
//            userAccess.addUser(user2);
//            Child child2 = new Child("Алексей2", "Бондаренко", "Петрович", Date.valueOf("2008-12-16"), "+79531367552");
//            userAccess.addChild(child2);
//   userAccess.setParent(2, 1);
//            Child child3 = new Child("Алексей3", "Бондаренко", "Петрович", Date.valueOf("2008-12-16"), "+79531367552");
//            userAccess.addChild(child3);
//            userAccess.setParent(2, 3);
//            userAccess.deleteUser(1);
//            userAccess.setParent(1, 2);
           userAccess.changeName(1, "Элечка");
           userAccess.getChildrenByUserId(2);
           userAccess.getParentByChildId(1);
        }
    }
}

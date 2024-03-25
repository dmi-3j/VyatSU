package ru.kotik.calendar.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.entities.Vaccine;
import ru.kotik.calendar.entities.VaccineComponent;
import ru.kotik.calendar.services.UserService;

import java.util.List;


@Controller
public class MedUserController {

    @Autowired
    private UserService userService;
    @GetMapping("/med/users")
    public String showMedUserPage(Model model) {
        model.addAttribute("user", new User());
        model.addAttribute("users", userService.getUsers());
        return "medUserPage";
    }
    @GetMapping("/med/users/filterUsers")
    public String filterUsers(Model model,
                                @RequestParam(value = "lastname", required = false) String lastname,
                                @RequestParam(value = "firstname", required = false) String firstname,
                                @RequestParam(value = "insnum", required = false) String insnum) {
        List<User> filteredUsers = userService.getUsers(lastname, firstname, insnum);
        model.addAttribute("users", filteredUsers);
        model.addAttribute("user", new User());
        model.addAttribute("lastname", lastname);
        model.addAttribute("firstname",  firstname);
        model.addAttribute("insnum", insnum);
        return "medUserPage";
    }
}

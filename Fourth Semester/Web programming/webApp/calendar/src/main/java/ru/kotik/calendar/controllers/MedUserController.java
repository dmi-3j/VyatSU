package ru.kotik.calendar.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.entities.Vaccine;
import ru.kotik.calendar.entities.VaccineComponent;
import ru.kotik.calendar.services.UserService;
import ru.kotik.calendar.services.VaccineComponentService;
import ru.kotik.calendar.services.VaccineService;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.UUID;


@Controller
public class MedUserController {

    @Autowired
    private UserService userService;

    @Autowired
    VaccineService vaccineService;

    @Autowired
    VaccineComponentService vaccineComponentService;
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
    @GetMapping("/med/users/info/{username}")
    public String userInfoPage(@PathVariable String username,
                               Model model) {
        User user = userService.getUserByUserName(username);
        List<Vaccine> vaccines = vaccineService.getAllVaccines(); // Получаем список вакцин
        model.addAttribute("user", user);
        model.addAttribute("vaccines", vaccines);
        return "userinfopage";
    }
    @PostMapping("/med/users/addVaccination")
    public String addVaccination(@RequestParam("serial") String serial,
                                 @RequestParam("vaccineName") String vaccineName,
                                 @RequestParam("componentName") UUID componentName,
                                 Model model) {
        // Ваш код для добавления вакцинации
        return "redirect:/med/users/info/{username}"; // Перенаправление на страницу информации о пользователе
    }
    @GetMapping("/med/vaccine/components/{vaccineId}")
    public ResponseEntity<?> getComponentsByVaccineId(@PathVariable int vaccineId) {
        List<VaccineComponent> components = vaccineComponentService.getComponentsByVaccineId(vaccineId);
        if (components != null && !components.isEmpty()) {
            return ResponseEntity.ok(components);
        } else {
            return ResponseEntity.notFound().build();
        }
    }


}



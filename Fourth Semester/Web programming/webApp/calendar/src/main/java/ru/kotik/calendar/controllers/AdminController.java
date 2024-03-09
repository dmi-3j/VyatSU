package ru.kotik.calendar.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import ru.kotik.calendar.entities.MedicalOrganzation;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.services.UserService;

import java.util.List;

@Controller
public class AdminController {

    @Autowired
    private UserService userService;

    @GetMapping("/manage")
    public String showAdminPage(Model model) {
        model.addAttribute("user", new User());
        model.addAttribute("users", userService.getAllMedUsers());
        model.addAttribute("medorg", new MedicalOrganzation());
        return "management";
    }

    @PostMapping("/manage/regMedUser")
    public String registerUser(User user) {
        userService.regMedUser(user);
        return "redirect:/manage";
    }

    @GetMapping("/manage/filterUsers")
    public String filterUsers(Model model,
                              @RequestParam(value = "lastname", required = false) String lastname,
                              @RequestParam(value = "phone", required = false) String phone,
                              @RequestParam(value = "username", required = false) String username) {
        List<User> filtermedusers = userService.getAllMedUsers(lastname, username, phone);
        model.addAttribute("users", filtermedusers);
        model.addAttribute("user", new User());
        model.addAttribute("lastname", lastname);
        model.addAttribute("username", username);
        model.addAttribute("phone", phone);
        return "management";
    }

    @GetMapping("/manage/disable/{username}")
    public String disable(Model model, @PathVariable(value = "username") String username) {
        userService.disableAccount(username);
        return "redirect:/manage";
    }

    @GetMapping("/manage/enable/{username}")
    public String enable(Model model, @PathVariable(value = "username") String username) {
        userService.enableAccount(username);
        return "redirect:/manage";
    }

    @GetMapping("/manage/edit/{username}")
    public String editMedUser(Model model,
                              @PathVariable(value = "username") String username) {
        User user = userService.getUserByUserName(username);
        model.addAttribute("user", user);
        return "manage";

    }
    @PostMapping("/manage/edit/")
    public String editMedUser(@ModelAttribute(value = "user") User updateuser){
        User user = userService.getUserByUserName(updateuser.getUsername());
        userService.update(user, updateuser);
        return "redirect:/manage";
    }



}

package ru.kotik.calendar.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class AdminController {

    @GetMapping("/manage")
    public String showAdminPage(Model model) {
        return "management";
    }




}

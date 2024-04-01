package ru.kotik.calendar.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.services.UserService;

@Controller
public class MainController {

    private UserDetailsService userDetailsService;

    @Autowired
    private UserService userService;

    @GetMapping("")
    public String mainPage(Model model) {
        model.addAttribute("user", new User());
        return "main";
    }

    @PostMapping("/authenticateTheUser")
    public String authenticateUser(@RequestParam("username") String username,
                                   @RequestParam("password") String password,
                                   Model model) {
        UserDetails userDetails = userDetailsService.loadUserByUsername(username);
        if (userDetails != null) {
            String storedPassword = userDetails.getPassword();
            if (password.equals(storedPassword)) {
                model.addAttribute("username", username);
                return "redirect:/main";
            }
        }
        model.addAttribute("error", true);
        return "main";
    }

    @GetMapping("/checkUsernameAvailability")
    public ResponseEntity<?> checkUsernameAvailability(@RequestParam String username) {
        boolean isAvailable = !userService.existsByUsername(username);
        return ResponseEntity.ok(isAvailable);
    }

    @GetMapping("/checkInsuranceNumberAvailability")
    public ResponseEntity<?> checkInsuranceNumberAvailability(@RequestParam String insuranceNumber) {
        boolean isAvailable = !userService.existsByInsuranceNumber(insuranceNumber);
        return ResponseEntity.ok(isAvailable);
    }

}

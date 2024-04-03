package ru.kotik.calendar.controllers;

import jakarta.servlet.http.HttpServletRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import ru.kotik.calendar.entities.MedicalOrganization;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.entities.Vaccine;
import ru.kotik.calendar.entities.VaccineComponent;
import ru.kotik.calendar.services.OrganizationService;
import ru.kotik.calendar.services.UserService;
import ru.kotik.calendar.services.VaccineComponentService;
import ru.kotik.calendar.services.VaccineService;

import java.util.List;
import java.util.UUID;

@Controller
public class AdminController {

    @Autowired
    private UserService userService;

    @Autowired
    private OrganizationService organizationService;

    @Autowired
    private VaccineService vaccineService;

    @Autowired
    private VaccineComponentService vaccineComponentService;

    @GetMapping("/manage")
    public String showAdminPage(Model model) {
        model.addAttribute("user", new User());
        model.addAttribute("users", userService.getAllMedUsers());
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
                              @RequestParam(value = "firstname", required = false) String firstname,
                              @RequestParam(value = "phone", required = false) String phone,
                              @RequestParam(value = "username", required = false) String username) {
        List<User> filtermedusers = userService.getAllMedUsers(lastname, username, phone, firstname);
        model.addAttribute("users", filtermedusers);
        model.addAttribute("user", new User());
        model.addAttribute("lastname", lastname);
        model.addAttribute("username", username);
        model.addAttribute("phone", phone);
        model.addAttribute("firstname", firstname);
        return "management";
    }

    @GetMapping("/manage/disable/{username}")
    public String disable(@PathVariable(value = "username") String username) {
        userService.disableAccount(username);
        return "redirect:/manage";
    }

    @GetMapping("/manage/enable/{username}")
    public String enable(@PathVariable(value = "username") String username) {
        userService.enableAccount(username);
        return "redirect:/manage";
    }

    @GetMapping("/manage/edit/{username}")
    public String editMedUser(Model model,
                              @PathVariable(value = "username") String username,
                              HttpServletRequest request) {
        User user = userService.getUserByUserName(username);
        model.addAttribute("user", user);
        String referer = request.getHeader("referer");
        model.addAttribute("referer", referer);
        return "edit";
    }

    @PostMapping("/manage/edit")
    public String editMedUserP(@ModelAttribute(value = "user") User updateuser) {
        User user = userService.getUserByUserName(updateuser.getUsername());
        userService.update(user, updateuser);
        return "redirect:/manage";
    }

    @GetMapping("/manage/organization")
    public String showAdminOrganizationPage(Model model) {
        model.addAttribute("organization", new MedicalOrganization());
        model.addAttribute("organizations", organizationService.getAllOrganizations());
        model.addAttribute("medorg", new MedicalOrganization());
        return "manageOrganization";
    }

    @PostMapping("/manage/organization/regMedOrg")
    public String regMedOrg(MedicalOrganization medicalOrganization) {
        organizationService.saveMedicalOrganization(medicalOrganization);
        return "redirect:/manage/organization";
    }

    @GetMapping("/manage/organization/filterOrganization")
    public String filterOrganization(Model model,
                                     @RequestParam(value = "name", required = false) String name,
                                     @RequestParam(value = "address", required = false) String address,
                                     @RequestParam(value = "phone", required = false) String phone) {
        List<MedicalOrganization> filteredOrganizations = organizationService.getAllOrganizations(name, address, phone);
        model.addAttribute("organizations", filteredOrganizations);
        model.addAttribute("medorg", new MedicalOrganization());
        model.addAttribute("name", name);
        model.addAttribute("address", address);
        model.addAttribute("phone", phone);
        return "manageOrganization";
    }

    @GetMapping("/manage/organization/edit/{id}")
    public String editMedOrg(Model model,
                             @PathVariable(value = "id") String id,
                             HttpServletRequest request) {
        int parseId = parseId(id);
        if (parseId == -1) return "error/404";
        MedicalOrganization medicalOrganization = organizationService.getMedicalOrganizationById(parseId);
        if (medicalOrganization == null) return "error/404";
        model.addAttribute("medorg", medicalOrganization);
        String referer = request.getHeader("referer");
        model.addAttribute("referer", referer);
        return "editMedOrg";
    }

    @PostMapping("/manage/organization/edit")
    public String editMedOrgP(@ModelAttribute(value = "medorg") MedicalOrganization updatedOrganization) {
        MedicalOrganization organization = organizationService.getMedicalOrganizationById(updatedOrganization.getId());
        organizationService.update(organization, updatedOrganization);
        return "redirect:/manage/organization";
    }

    @GetMapping("/manage/vaccine")
    public String showAdminVaccineManagePage(Model model) {
        model.addAttribute("vaccine", new Vaccine());
        model.addAttribute("vaccines", vaccineService.getAllVaccines());
        model.addAttribute("component", new VaccineComponent());
        return "manageVaccine";
    }

    @GetMapping("/manage/vaccine/add")
    public String showAddNewVaccinePage(Model model,
                                        HttpServletRequest request) {
        model.addAttribute("vaccine", new Vaccine());
        model.addAttribute("component", new VaccineComponent());
        String referer = request.getHeader("referer");
        model.addAttribute("referer", referer);
        return "addNewVaccineWithComponents";
    }

    @PostMapping("/manage/vaccine/add")
    public String addNewVaccineWithComponents(@ModelAttribute Vaccine vaccine) {
        vaccineService.saveVaccine(vaccine);

        for (VaccineComponent component : vaccine.getComponents()) {
            component.setVaccine(vaccine);
            vaccineComponentService.saveVaccineComponent(component);
        }
        return "redirect:/manage/vaccine";
    }

    @GetMapping("/manage/vaccine/filterVaccine")
    public String filterVaccine(Model model,
                                @RequestParam(value = "name", required = false) String name,
                                @RequestParam(value = "country", required = false) String country,
                                @RequestParam(value = "valid", required = false) String valid) {
        List<Vaccine> filteredVaccine = vaccineService.getAllVaccines(name, country, valid);
        model.addAttribute("vaccines", filteredVaccine);
        model.addAttribute("vaccine", new Vaccine());
        model.addAttribute("name", name);
        model.addAttribute("country", country);
        model.addAttribute("valid", valid);
        return "manageVaccine";
    }

    @GetMapping("/manage/vaccine/info/{id}")
    public String vaccineInfo(Model model,
                              @PathVariable(value = "id") String id,
                              HttpServletRequest request) {
        int parseId = parseId(id);
        if (parseId == -1) return "error/404";
        Vaccine vaccine = vaccineService.getVaccineById(parseId);
        if (vaccine == null) return "error/404";
        model.addAttribute("vaccine", vaccine);
        String referer = request.getHeader("referer");
        model.addAttribute("referer", referer);
        return "vaccineinfo";
    }

    private int parseId(String id) {
        try {
            return Integer.parseInt(id);
        } catch (NumberFormatException e) {
            return -1;
        }
    }
}

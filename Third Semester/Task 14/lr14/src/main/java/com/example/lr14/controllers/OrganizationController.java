package com.example.lr14.controllers;

import jakarta.annotation.PostConstruct;
import org.springframework.ui.Model;
import com.example.lr14.entities.MedicalOrganization;
import com.example.lr14.services.OrganizationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@Controller
@RequestMapping("/organizations")
public class OrganizationController {
    private OrganizationService organizationService;

    @Autowired
    public void setOrganizationService(OrganizationService organizationService) {
        this.organizationService = organizationService;
    }
    @GetMapping
    public String showOrganizationsList(Model model) {
        MedicalOrganization organization = new MedicalOrganization();
        model.addAttribute("organizations", organizationService.getAllOrganizations());
        model.addAttribute("organization", organization);
        return "organizations";
    }
    @PostMapping("/add")
    public String addOrganization(@ModelAttribute(value = "medicalorganization")MedicalOrganization medicalorganization) {
        organizationService.add(medicalorganization);
        return "redirect:/organizations";
    }
}

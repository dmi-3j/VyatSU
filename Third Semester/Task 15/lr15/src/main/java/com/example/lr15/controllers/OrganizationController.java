package com.example.lr15.controllers;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.ui.Model;
import com.example.lr15.entities.MedicalOrganization;
import com.example.lr15.services.OrganizationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.util.UriComponentsBuilder;

import java.util.List;

@Controller
public class OrganizationController {
    private OrganizationService organizationService;
    private UserDetailsService userDetailsService;

    @Autowired
    public void setOrganizationService(OrganizationService organizationService) {
        this.organizationService = organizationService;
    }

    @GetMapping("")
    public String showOrganizationsList(Model model, @RequestParam(defaultValue = "0") int page) {
        Pageable pageable = PageRequest.of(page, 5);
        Page<MedicalOrganization> organizationPage = organizationService.getAllOrganizations(pageable);
        model.addAttribute("organizations", organizationPage.getContent());
        model.addAttribute("organization", new MedicalOrganization());
        model.addAttribute("currentPage", page);
        model.addAttribute("totalPages", organizationPage.getTotalPages());
        List<MedicalOrganization> topOrganizations = organizationService.getTopOrganizations();
        model.addAttribute("topOrganizations", topOrganizations);
        return "organizations";
    }

    @PostMapping("/organizations/addOrUpdate/add")
    public String addOrganization(@ModelAttribute(value = "medicalorganization") MedicalOrganization medicalorganization) {
        organizationService.add(medicalorganization);
        return "redirect:/";
    }

    @GetMapping("/organizations/addOrUpdate/add")
    public String test(Model model,
                       @RequestHeader(value = "Referer") String referer) {
        Page<MedicalOrganization> organizationPage = organizationService.getAllOrganizations(PageRequest.of(0, 5));
        model.addAttribute("organizations", organizationPage.getContent());
        model.addAttribute("organization", new MedicalOrganization());
        model.addAttribute("referer", referer);
        return "addOrUpdate";
    }

    @GetMapping("/organizations/addOrUpdate/edit/{id}")
    public String editOrganization(Model model, @PathVariable(value = "id") Integer id,
                                   @RequestHeader(value = "Referer") String referer) {
        MedicalOrganization medicalOrganization = organizationService.getById(id);
        model.addAttribute("organization", medicalOrganization);
        model.addAttribute("referer", referer);
        return "addOrUpdate";
    }

    @PostMapping("/organizations/addOrUpdate/edit")
    public String updateOrganization(@ModelAttribute(value = "organization") MedicalOrganization updatedOrganization) {
        MedicalOrganization organization = organizationService.getById(updatedOrganization.getId());
        organizationService.update(organization, updatedOrganization);
        return "redirect:/";
    }

    @GetMapping("/organizations/show/{id}")
    public String showOneOrganization(Model model, @PathVariable(value = "id") Integer id,
                                      @RequestHeader(value = "Referer") String referer) {
        MedicalOrganization medicalOrganization = organizationService.getById(id);
        organizationService.incViews(medicalOrganization);
        model.addAttribute("organization", medicalOrganization);
        model.addAttribute("referer", referer);
        return "organization-info";
    }

    @GetMapping("/organizations/delete/{id}")
    public String deleteOrganizations(@PathVariable(value = "id") Integer id) {
        MedicalOrganization medicalOrganization = organizationService.getById(id);
        organizationService.delete(medicalOrganization);
        return "redirect:/";
    }

    @GetMapping("/organizations/filter")
    public String filterOrganizations(Model model,
                                      @RequestParam(value = "name", required = false) String name,
                                      @RequestParam(value = "address", required = false) String address,
                                      @RequestParam(value = "openingtime", required = false) Integer openingtime,
                                      @RequestParam(defaultValue = "0") int page) {
        MedicalOrganization medicalOrganization = new MedicalOrganization();

        Pageable pageable = PageRequest.of(page, 5);
        Page<MedicalOrganization> organizationPage = organizationService.getAllOrganizations(name, address, openingtime, pageable);

        model.addAttribute("organizations", organizationPage.getContent());
        model.addAttribute("organization", medicalOrganization);
        model.addAttribute("name", name);
        model.addAttribute("address", address);
        model.addAttribute("openingtime", openingtime);
        model.addAttribute("currentPage", page);
        model.addAttribute("totalPages", organizationPage.getTotalPages());

        List<MedicalOrganization> topOrganizations = organizationService.getTopOrganizations();
        model.addAttribute("topOrganizations", topOrganizations);

        UriComponentsBuilder uriBuilder = UriComponentsBuilder.fromUriString("/organizations/filter");
        if (name != null && !name.isEmpty()) uriBuilder.queryParam("name", name);
        if (address != null && !address.isEmpty()) uriBuilder.queryParam("address", address);
        if (openingtime != null) uriBuilder.queryParam("openingtime", openingtime);
        model.addAttribute("filterUrl", uriBuilder.build().toString());

        return "organizations";
    }

    @PostMapping("/authenticateTheUser")
    public String authenticateUser(@RequestParam("username") String username, @RequestParam("password") String password, Model model) {
        UserDetails userDetails = userDetailsService.loadUserByUsername(username);
        if (userDetails != null) {
            String storedPassword = userDetails.getPassword();
            if (password.equals(storedPassword)) {
                model.addAttribute("username", username);
                return "redirect:/organizations";
            }
        }
        return "organizations";
    }
}
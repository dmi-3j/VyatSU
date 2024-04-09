package ru.kotik.calendar.controllers;

import com.amazonaws.client.builder.AwsClientBuilder;
import com.amazonaws.services.s3.model.CannedAccessControlList;
import com.amazonaws.services.s3.model.DeleteObjectRequest;
import com.amazonaws.services.s3.model.ObjectMetadata;
import jakarta.servlet.http.HttpServletRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.ldap.embedded.EmbeddedLdapProperties;
import org.springframework.boot.autoconfigure.security.saml2.Saml2RelyingPartyProperties;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;
import ru.kotik.calendar.entities.*;
import ru.kotik.calendar.services.ReactionService;
import ru.kotik.calendar.services.UserService;

import java.io.IOException;
import java.security.Principal;
import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Random;

import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.PutObjectRequest;
import ru.kotik.calendar.services.VaccinationService;

@Controller
public class UserController {

    private UserService userService;

    @Autowired
    public void setUserService(UserService userService) {
        this.userService = userService;
    }

    @Autowired
    private VaccinationService vaccinationService;

    @Autowired
    private ReactionService reactionService;

    @PostMapping("profile/uploadPhoto")
    public String uploadPhoto(@RequestParam("username") String username,
                              @RequestParam("file") MultipartFile file) {
        if (!file.isEmpty()) {
            try {
                BasicAWSCredentials awsCreds = new BasicAWSCredentials("r64QBDrKHTb7kZXsuRwEHy", "bVDPh71kQTgx2ZbaHYDM1A5fPsaafLDDwSaVuWMadyir");
                AmazonS3 s3Client = AmazonS3ClientBuilder.standard()
                        .withCredentials(new AWSStaticCredentialsProvider(awsCreds))
                        .withEndpointConfiguration(new AwsClientBuilder.EndpointConfiguration("https://hb.ru-msk.vkcs.cloud", "ru-msk"))
                        .build();
                User user = userService.getUserByUserName(username);
                String previousPhotoPath = user.getPhotopath();
                String bucketName = "webuploads";
                if (previousPhotoPath != null && !previousPhotoPath.isEmpty() && !previousPhotoPath.equals("https://webuploads.hb.ru-msk.vkcs.cloud/default.jpg")) {
                    String previousFileName = previousPhotoPath.substring(previousPhotoPath.lastIndexOf("/") + 1);
                    DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest(bucketName, previousFileName);
                    s3Client.deleteObject(deleteObjectRequest);
                }
                String randomString = generateRandomString(8);
                String fileName = username + randomString;
                ObjectMetadata metadata = new ObjectMetadata();
                metadata.setContentLength(file.getSize());
                s3Client.putObject(new PutObjectRequest(bucketName, fileName, file.getInputStream(), metadata).withCannedAcl(CannedAccessControlList.PublicRead));
                user.setPhotopath(s3Client.getUrl(bucketName, fileName).toString());
                userService.saveUser(user);
                return "redirect:/profile";
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return "redirect:/profile";
    }

    @PostMapping("/register")
    public String registerUser(User user) {
        userService.regUser(user);
        return "redirect:/";
    }

    @GetMapping("/profile")
    public String getProfile(Model model, Principal principal) {
        String username = principal.getName();
        User user = userService.getUserByUserName(username);
        String name = user.getFirstname();
        String photoPath = user.getPhotopath();

        SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");
        String formattedDateOfBirth = dateFormat.format(user.getDateofbirth());
        model.addAttribute("username", name);
        model.addAttribute("photoPath", photoPath);
        model.addAttribute("lastname", user.getLastname());
        model.addAttribute("dateofbirth", formattedDateOfBirth);
        model.addAttribute("phonenumber", user.getPhonenumber());
        model.addAttribute("address", user.getAddress());
        model.addAttribute("inshurancenumber", user.getInshurancenumber());

        return "profile";
    }

    public static String generateRandomString(int length) {
        String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder randomString = new StringBuilder();
        Random random = new Random();
        for (int i = 0; i < length; i++) {
            char randomChar = characters.charAt(random.nextInt(characters.length()));
            randomString.append(randomChar);
        }
        return randomString.toString();
    }

    @GetMapping("/user/vaccinations")
    public String showMainUserPage(Principal principal, Model model) {

        User user = userService.getUserByUserName(principal.getName());
        model.addAttribute("user", user);
        List<Vaccination> vaccinations = vaccinationService.getVaccinationsByUser(user);
        model.addAttribute("vaccinations", vaccinations);
        model.addAttribute("vaccination", new Vaccination());
        return "mainuserpage";
    }
    @GetMapping("/user/filterVaccination")
    public String filterVaccination(@RequestParam("seria") String seria,
                                    @RequestParam("vcc") String vaccineName,
                                    Model model,
                                    Principal principal) {
        String u = principal.getName();
        User user = userService.getUserByUserName(u);
        model.addAttribute("user", user);
        List<Vaccination> vaccinations = vaccinationService.getVaccinationsByUser(user, seria, vaccineName);
        model.addAttribute("vaccinations", vaccinations);
        model.addAttribute("vaccination", new Vaccination());
        model.addAttribute("username", u);
        model.addAttribute("seria", seria);
        model.addAttribute("vaccineName", vaccineName);

        return "mainuserpage";
    }
    @GetMapping("/user/vaccination/info/{id}")
    public String vaccinationInfo(Model model,
                                  @PathVariable(value = "id") String id,
                                  Principal principal) {
        String username = principal.getName();
        int parseId = parseId(id);
        if (parseId == -1) return "error/404";
        Vaccination vaccination = vaccinationService.getById(parseId);
        if (vaccination == null) return "error/404";
        if (!vaccination.getUser().getUsername().equals(username)) {
            return "error/403";
        }
        model.addAttribute("vaccination", vaccination);
        List<Reaction> reactions = vaccination.getReactions();
        model.addAttribute("reactions", reactions);
        model.addAttribute("reaction", new Reaction());
        return "uservaccinationinfopage";
    }
    private int parseId(String id) {
        try {
            return Integer.parseInt(id);
        } catch (NumberFormatException e) {
            return -1;
        }
    }

    @PostMapping("/addreaction")
    public String addReaction(@RequestParam("id") int id,
                              @RequestParam("reaction") String reaction) {

        Vaccination vaccination = vaccinationService.getById(id);
        reactionService.saveReaction(vaccination, reaction);
        return "redirect:/";
    }
    @GetMapping("/user/reaction/del/{id}")
    public String deleteReaction(@PathVariable(value = "id") int id,
                                 @RequestParam(value = "vaccinationId") int vaccinationId) {
        Reaction reaction = reactionService.getById(id);
        reactionService.deleteReaction(reaction);
        return "redirect:/user/vaccination/info/" + vaccinationId;
    }
    @PostMapping("/profile/edit")
    public String editProfileP(@ModelAttribute(value = "user") User updateuser) {
        User user = userService.getUserByUserName(updateuser.getUsername());
        userService.update(user, updateuser);
        return "redirect:/profile";
    }
    @GetMapping("/profile/editProfile")
    public String editMedUser(Model model, Principal principal,
                              HttpServletRequest request) {
        User user = userService.getUserByUserName(principal.getName());
        model.addAttribute("user", user);
        String referer = request.getHeader("referer");
        model.addAttribute("referer", referer);

        return "editProfile";
    }
}

package ru.kotik.calendar.controllers;

import com.amazonaws.client.builder.AwsClientBuilder;
import com.amazonaws.services.s3.model.CannedAccessControlList;
import com.amazonaws.services.s3.model.DeleteObjectRequest;
import com.amazonaws.services.s3.model.ObjectMetadata;
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
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.multipart.MultipartFile;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.services.UserService;

import java.io.IOException;
import java.security.Principal;
import java.text.SimpleDateFormat;
import java.util.Random;

import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.PutObjectRequest;

@Controller
public class UserController {

    private UserService userService;
    @Autowired
    public void setUserService(UserService userService) {
        this.userService = userService;
    }

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


                if (previousPhotoPath != null && !previousPhotoPath.isEmpty() && !previousPhotoPath.equals("https://webuploads.hb.ru-msk.vkcs.cloud/default.jpg\n")) {
                    String previousFileName = previousPhotoPath.substring(previousPhotoPath.lastIndexOf("/") + 1);
                    System.out.println(previousFileName);
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
    //https://webuploads.hb.ru-msk.vkcs.cloud/default.jpg

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

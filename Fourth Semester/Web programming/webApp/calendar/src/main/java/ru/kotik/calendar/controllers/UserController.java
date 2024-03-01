package ru.kotik.calendar.controllers;

import com.amazonaws.client.builder.AwsClientBuilder;
import com.amazonaws.services.s3.model.CannedAccessControlList;
import com.amazonaws.services.s3.model.ObjectMetadata;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.multipart.MultipartFile;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.services.UserService;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.PutObjectRequest;

//import com.vk.api.sdk.client.VkApiClient;
//import com.vkcloud.sdk.VKCloudClientBuilder;
//import com.vkcloud.sdk.requests.PutObjectRequest;

// Другие импорты

@Controller
public class UserController {

    // Другие методы контроллера
    private UserService userService;
    @Autowired
    public void setUserService(UserService userService) {
        this.userService = userService;
    }

    @PostMapping("profile/uploadPhoto")
    public String uploadPhoto(@RequestParam("username") String username,
                              @RequestParam("file") MultipartFile file) {
        // Проверка наличия файла
        if (!file.isEmpty()) {
            try {
                // Создание учетных данных
                BasicAWSCredentials awsCreds = new BasicAWSCredentials("r64QBDrKHTb7kZXsuRwEHy", "bVDPh71kQTgx2ZbaHYDM1A5fPsaafLDDwSaVuWMadyir");
                System.out.println("test");
                // Создание клиента Amazon S3 с учетными данными
                AmazonS3 s3Client = AmazonS3ClientBuilder.standard()
                        .withCredentials(new AWSStaticCredentialsProvider(awsCreds))
                        .withEndpointConfiguration(new AwsClientBuilder.EndpointConfiguration("https://hb.ru-msk.vkcs.cloud", "ru-msk"))
                        .build();
                String bucketName = "webuploads";
                String fileName = username + "Photo";
                ObjectMetadata metadata = new ObjectMetadata();
                metadata.setContentLength(file.getSize());
                s3Client.putObject(new PutObjectRequest(bucketName, fileName, file.getInputStream(), metadata).withCannedAcl(CannedAccessControlList.PublicRead));

                // Обновление пути к фотографии в объекте User
                User user = userService.getUserByUserName(username);
                user.setPhotoPath(s3Client.getUrl(bucketName, fileName).toString());
                userService.saveUser(user);

                // Редирект на страницу профиля
                return "redirect:/profile";
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        // В случае ошибки, редирект на страницу с сообщением об ошибке
        return "redirect:/main";
    }

}

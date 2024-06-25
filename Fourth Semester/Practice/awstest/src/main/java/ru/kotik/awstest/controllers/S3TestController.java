package ru.kotik.awstest.controllers;

import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.model.*;
import jakarta.annotation.PostConstruct;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.multipart.MultipartFile;
import java.io.IOException;

@Controller
public class S3TestController {

    private final AmazonS3 s3Client;
    private final String bucketName;

    @Autowired
    public S3TestController(AmazonS3 s3Client, String bucketName) {
        this.s3Client = s3Client;
        this.bucketName = bucketName;
    }
    @GetMapping("/")
    public String manageS3(Model model) {
        ObjectListing objectListing = s3Client.listObjects(bucketName);
        model.addAttribute("files", objectListing);
        return "testS3";
    }
    @PostMapping("/manage/uploadFile")
    public String uploadFile(@RequestParam("file") MultipartFile file) {
        if (!file.isEmpty()) {
            try {
                String originalFilename = file.getOriginalFilename();
                ObjectMetadata metadata = new ObjectMetadata();
                metadata.setContentLength(file.getSize());
                metadata.setContentType(file.getContentType());
                PutObjectRequest putObjectRequest = new PutObjectRequest(bucketName, originalFilename, file.getInputStream(), metadata)
                        .withCannedAcl(CannedAccessControlList.PublicRead);
                s3Client.putObject(putObjectRequest);
                return "redirect:/";
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return "redirect:/";
    }
    @GetMapping("/manage/downloadFile/{fileName}")
    public String downloadFile(@PathVariable String fileName) {
        String url = s3Client.getUrl(bucketName, fileName).toString();
        return "redirect:" + url;
    }
    @GetMapping("/manage/deleteFile/{fileName}")
    public String deleteFile(@PathVariable String fileName) {
        DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest(bucketName, fileName);
        s3Client.deleteObject(deleteObjectRequest);
        return "redirect:/";
    }
}
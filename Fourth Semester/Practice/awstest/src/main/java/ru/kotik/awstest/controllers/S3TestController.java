package ru.kotik.awstest.controllers;

import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.client.builder.AwsClientBuilder;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.*;
import jakarta.annotation.PostConstruct;
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

    private AmazonS3 s3Client;
    private String bucketName;

    @PostConstruct
    private void init() {
        //BasicAWSCredentials awsCreds = new BasicAWSCredentials("accessKey1", "verySecretKey1");
        BasicAWSCredentials awsCreds = new BasicAWSCredentials("03307e84ecab4d02ca9ed044", "f21fd124c92cae909ea30a4d505be9e0a6fbee11d3030614eb9ceee2019c80c7");
        s3Client = AmazonS3ClientBuilder.standard()
                .withCredentials(new AWSStaticCredentialsProvider(awsCreds))
                .withEndpointConfiguration(new AwsClientBuilder.EndpointConfiguration("http://127.0.0.1:8000", "us-east-1"))
                .withPathStyleAccessEnabled(true)
                .build();
        bucketName = "testbucket";
        if (!s3Client.doesBucketExistV2(bucketName)) {
            s3Client.createBucket(new CreateBucketRequest(bucketName));
            s3Client.setBucketAcl(bucketName, CannedAccessControlList.PublicRead);
        }
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
    public String disable(@PathVariable String fileName) {
        DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest(bucketName, fileName);
        s3Client.deleteObject(deleteObjectRequest);
        return "redirect:/";
    }
}
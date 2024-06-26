package ru.kotik.awstest.configuration;

import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.client.builder.AwsClientBuilder;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.CannedAccessControlList;
import com.amazonaws.services.s3.model.CreateBucketRequest;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;

@Configuration
@ComponentScan("ru.kotik.awstest")
public class AppConfig {

    @Value("${aws.accessKeyId}")
    private String accessKeyId;

    @Value("${aws.secretKey}")
    private String secretKey;

    @Value("${aws.serviceEndpoint}")
    private String s3ServiceEndpoint;

    @Value("${aws.bucketName}")
    private String bucketName;

    @Bean
    public AmazonS3 s3Client() {
        AmazonS3 s3Client =  AmazonS3ClientBuilder.standard()
                .withCredentials(new AWSStaticCredentialsProvider(new BasicAWSCredentials(accessKeyId, secretKey)))
                .withEndpointConfiguration(new AwsClientBuilder.EndpointConfiguration(s3ServiceEndpoint, "us-east-1"))
                .withPathStyleAccessEnabled(true)
                .build();

        if (!s3Client.doesBucketExistV2(bucketName)) {
            s3Client.createBucket(new CreateBucketRequest(bucketName));
            s3Client.setBucketAcl(bucketName, CannedAccessControlList.PublicRead);
        }
        return s3Client;
    }

    @Bean
    public String bucketName() {
        return bucketName;
    }


}

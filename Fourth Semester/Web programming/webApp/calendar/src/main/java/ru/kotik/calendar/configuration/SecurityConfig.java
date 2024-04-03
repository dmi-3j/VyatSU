package ru.kotik.calendar.configuration;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.web.SecurityFilterChain;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.services.UserService;

@Configuration
@EnableWebSecurity
public class SecurityConfig {

    @Bean
    public SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
        return http
                .authorizeHttpRequests(auth -> auth
                        .requestMatchers("/profile/**").authenticated()
                        .requestMatchers("/manage/**").hasRole("ADMIN")
                        .requestMatchers("/med/**").hasRole("MED")
                        .requestMatchers("/user/**").hasRole("USER")
                        .anyRequest().permitAll())
                .formLogin((form) -> form
                        .loginPage("/")
                        .loginProcessingUrl("/authenticateTheUser")
                        .permitAll())
                .logout((logout) -> logout
                        .logoutSuccessUrl("/")
                        .permitAll())
                .build();
    }
    @Bean
    public PasswordEncoder passwordEncoder() {
        return new BCryptPasswordEncoder();
    }
    @Bean
    public UserDetailsService userDetailsService(UserService userService) {
        return username -> {
            User user = userService.getUserByUserName(username);
            return org.springframework.security.core.userdetails.User
                    .withUsername(username)
                    .password(user.getPassword()).authorities(userService.getAuthorityByusername(username))
                    .disabled(!user.getEnabled())
                    .build();
        };
    }
}

package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.Authority;
import ru.kotik.calendar.repositories.UserRepository;
import ru.kotik.calendar.entities.User;

import java.util.List;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public User getUserById(Integer id) {
        return userRepository.findById(id).orElse(null);
    }
    public User getUserByUserName(String username) {
        User user = userRepository.findByusername(username);
        if (user == null) throw  new UsernameNotFoundException(username);
        return user;
    }


    public List<User> getAllUsers() {
        return userRepository.findAll();
    }

    public void regUser(User user) {
        user.setEnabled(true);
        encodePassword(user);
        Authority authority = new Authority();
        authority.setAuthority("ROLE_USER");
        authority.setUser(user);
        user.setAuthority(authority);
        saveUser(user);
    }
    public void saveUser(User user) {
        userRepository.save(user);
    }

    public void deleteUser(Integer id) {
        userRepository.deleteById(id);
    }

    public String getRealNameByUsername(String username) {
        User user = userRepository.findByusername(username);
        return (user != null) ? user.getFirstname() : "";
    }
    public String getAuthorityByusername(String username) {
        User user = userRepository.findByusername(username);
        return (user != null && user.getAuthority() != null) ? user.getAuthority().getAuthority() : null;
    }
    public void encodePassword(User user) {
        PasswordEncoder passwordEncoder = new BCryptPasswordEncoder();
        String encodedPassword = passwordEncoder.encode(user.getPassword());
        user.setPassword(encodedPassword);
        userRepository.save(user);
    }
}

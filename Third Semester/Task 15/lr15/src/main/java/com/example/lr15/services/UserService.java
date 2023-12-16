package com.example.lr15.services;

import com.example.lr15.entities.Authority;
import com.example.lr15.entities.User;
import com.example.lr15.repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public User getUserById(Integer id) {
        return userRepository.findById(id).orElse(null);
    }
    public User getUserByUserName(String username) {
        return userRepository.findByusername(username);
    }
    public List<User> getAllUsers() {
        return userRepository.findAll();
    }
    public void saveUser(User user) {
        userRepository.save(user);
    }
    public void deleteUser(Integer id) {
        userRepository.deleteById(id);
    }
    public List<Authority> getUserAuthorities(String username) {
       return userRepository.getAuthoritiesByusername(username);
    }
    public String getRealNameByUsername(String username) {
        User user = userRepository.findByusername(username);
        return (user != null) ? user.getName() : "";
    }

}

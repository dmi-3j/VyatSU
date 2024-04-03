package ru.kotik.calendar.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import ru.kotik.calendar.entities.Authority;
import ru.kotik.calendar.repositories.UserRepository;
import ru.kotik.calendar.entities.User;
import ru.kotik.calendar.specifications.MedUserSpecification;
import ru.kotik.calendar.specifications.UserSpecification;

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
        if (user == null) throw new UsernameNotFoundException(username);
        return user;
    }

    public boolean existsByUsername(String username) {
        return userRepository.existsByUsername(username);
    }

    public boolean existsByInsuranceNumber(String inshurancenumber) {
        return userRepository.existsByInshurancenumber(inshurancenumber);
    }

    public List<User> getAllUsers() {
        return userRepository.findAll();
    }

    public List<User> getAllMedUsers() {
        return userRepository.findUsersByAuthority_Authority("ROLE_MED");
    }

    public List<User> getUsers() {
        return userRepository.findUsersByAuthority_Authority("ROLE_USER");
    }

    public List<User> getUsers(String lastname, String firstname, String insNum) {
        Specification<User> specification = Specification
                .where(UserSpecification.hasLastName(lastname))
                .and(UserSpecification.hasFirstName(firstname))
                .and(UserSpecification.hasInsNum(insNum));
        return userRepository.findAll(specification);
    }

    public List<User> getAllMedUsers(String lastname, String username, String phone, String firstname) {
        Specification<User> specification = Specification
                .where(MedUserSpecification.hasLastName(lastname))
                .and((MedUserSpecification.hasUserName(username)))
                .and(MedUserSpecification.hasPhone(phone))
                .and(MedUserSpecification.hasFirstName(firstname));
        return userRepository.findAll(specification);
    }

    public void disableAccount(String username) {
        User user = userRepository.findByusername(username);
        user.setEnabled(false);
        saveUser(user);
    }

    public void enableAccount(String username) {
        User user = userRepository.findByusername(username);
        user.setEnabled(true);
        saveUser(user);
    }

    public void regUser(User user) {
        user.setEnabled(true);
        encodePassword(user);
        Authority authority = new Authority();
        authority.setAuthority("ROLE_USER");
        authority.setUser(user);
        user.setAuthority(authority);
        user.setPhotopath("https://webuploads.hb.ru-msk.vkcs.cloud/default.jpg");
        saveUser(user);
    }

    public void regMedUser(User user) {
        user.setEnabled(true);
        encodePassword(user);
        Authority authority = new Authority();
        authority.setAuthority("ROLE_MED");
        authority.setUser(user);
        user.setAuthority(authority);
        user.setPhotopath("https://webuploads.hb.ru-msk.vkcs.cloud/default.jpg");
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

    public void update(User exist, User updated) {
        if (!(updated.getFirstname() == null) && !updated.getFirstname().isBlank())
            exist.setFirstname(updated.getFirstname());
        if (!(updated.getLastname() == null) && !updated.getLastname().isBlank())
            exist.setLastname(updated.getLastname());
        if (!(updated.getPhonenumber() == null) && !updated.getPhonenumber().isBlank())
            exist.setPhonenumber(updated.getPhonenumber());
        if (!(updated.getPassword() == null) && !updated.getPassword().isBlank()) {
            exist.setPassword(updated.getPassword());
            encodePassword(exist);
        }
        if (!(updated.getAddress() == null) && !updated.getAddress().isBlank())
            exist.setAddress((updated.getAddress()));
        userRepository.save(exist);
    }
}

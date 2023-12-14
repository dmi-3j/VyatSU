package com.example.lr15.services;

import org.springframework.dao.EmptyResultDataAccessException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.core.authority.SimpleGrantedAuthority;

import javax.sql.DataSource;
import java.util.List;

public class JdbcUserDetailsService implements UserDetailsService {

    private final JdbcTemplate jdbcTemplate;

    public JdbcUserDetailsService(DataSource dataSource) {
        this.jdbcTemplate = new JdbcTemplate(dataSource);
    }

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        String query = "SELECT username, password, enabled FROM users WHERE username = ?";
        try {
            UserDetails user = jdbcTemplate.queryForObject(query, new Object[]{username}, (rs, rowNum) -> {
                String fetchedUsername = rs.getString("username");
                String password = rs.getString("password");
                boolean enabled = rs.getBoolean("enabled");
                return User.withUsername(fetchedUsername)
                        .password(password)
                        .disabled(!enabled)
                        .build();
            });

            // Загрузка ролей пользователя
            List<GrantedAuthority> authorities = loadUserAuthorities(username);
            return new User(user.getUsername(), user.getPassword(), user.isEnabled(), true, true, true, authorities);
        } catch (EmptyResultDataAccessException e) {
            throw new UsernameNotFoundException("User not found");
        }
    }

    private List<GrantedAuthority> loadUserAuthorities(String username) {
        String query = "SELECT authority FROM authorities WHERE username = ?";
        return jdbcTemplate.query(query, new Object[]{username}, (rs, rowNum) -> new SimpleGrantedAuthority(rs.getString("authority")));
    }


}

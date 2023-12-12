CREATE TABLE medicalorganization
(
    id    serial primary key,
    name varchar(100),
    address varchar(250),
    phone varchar(13),
    timeofwork varchar (13)
);

INSERT INTO medicalorganization (name, address, phone, timeofwork)
VALUES
('Травмпункт', 'Менделеева 16','88005553535', '7-21'),
('Больница №1', 'Кирова 8','88001000101', '10-17'),
('Центр крови', 'Красноармейская 47','88124360736', '7-13');

CREATE TABLE users
(
    username VARCHAR(50)  NOT NULL,
    password VARCHAR(100) NOT NULL,
    enabled  boolean      NOT NULL,
    PRIMARY KEY (username)
);

INSERT INTO users
VALUES ('admin', '123', true),
       ('user', '456', true);

CREATE TABLE authorities
(
    username  varchar(50) NOT NULL,
    authority varchar(50) NOT NULL,

    CONSTRAINT authorities_idx UNIQUE (username, authority),

    CONSTRAINT authorities_ibfk_1
        FOREIGN KEY (username)
            REFERENCES users (username)
);

INSERT INTO authorities
VALUES ('admin', 'ROLE_ADMIN'),
       ('admin', 'ROLE_USER'),
       ('user', 'ROLE_USER');
CREATE TABLE medicalorganization
(
    id          serial primary key,
    name        varchar(100),
    address     varchar(250),
    phone       varchar(13),
    openingtime numeric(2),
    closingtime numeric(2),
    views       int not null default 0
);

INSERT INTO medicalorganization (name, address, phone, openingtime, closingtime, views)
VALUES ('Травмпункт', 'Менделеева 16', '88005553535', 7, 21, 0),
       ('Больница №1', 'Кирова 8', '88001000101', 10, 21, 0),
       ('Центр крови', 'Красноармейская 47', '88124360736', 7, 13, 0);

CREATE TABLE users
(
    username VARCHAR(50)  NOT NULL,
    password VARCHAR(100) NOT NULL,
    name     VARCHAR(20)  NOT NULL,
    enabled  boolean      NOT NULL,
    PRIMARY KEY (username)
);

INSERT INTO users
VALUES ('admin', '$2a$10$dYJ9JcdxtCIc6jnJYNTDFOs1tdPt1te25Gf5JKIEc7uRBvJiSk6JO', 'Дмитрий', true),
       ('user', '$2a$10$zxVS3muLezmSlzipO76OVuUsEPwxBzgYrMMBXu.b383sFiaO.rB5m', 'Бесправный Юзер', true);

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
       ('user', 'ROLE_USER');
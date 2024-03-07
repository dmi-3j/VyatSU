CREATE TABLE users
(
    username VARCHAR(50)  NOT NULL,
    password VARCHAR(100) NOT NULL,
    firstname     VARCHAR(30)  NOT NULL,
    lastname     VARCHAR(30)  NOT NULL,
    middlename     VARCHAR(30),
    dateofbirth date NOT NULL,
    address VARCHAR(150) not null,
    phonenumber VARCHAR(14) not null ,
    inshurancenumber VARCHAR(16) not null,
    photopath varchar(250),
    enabled  boolean      NOT NULL,
    PRIMARY KEY (username),
    UNIQUE (inshurancenumber),
    UNIQUE (phonenumber)
);

INSERT INTO users(username, password, firstname, lastname, middlename, dateofbirth, address, phonenumber, inshurancenumber, photopath, enabled)
VALUES ('admin', '$2a$10$dYJ9JcdxtCIc6jnJYNTDFOs1tdPt1te25Gf5JKIEc7uRBvJiSk6JO', 'Дмитрий','Субботин',null, '2001-05-15'::date,'Студенческий проезд 3а, кв.56', '+79128285795', '1234123412341234', null,  true),
       ('user', '$2a$10$zxVS3muLezmSlzipO76OVuUsEPwxBzgYrMMBXu.b383sFiaO.rB5m', 'Иван', 'Иванов',null, '2005-01-21'::date,'Ленина  31, кв.23', '+79223334455', '3214222134552121', null, true);

CREATE TABLE authorities
(
    username  varchar(50) NOT NULL,
    authority varchar(50) NOT NULL,

    CONSTRAINT authorities_idx UNIQUE (username, authority),

    CONSTRAINT authorities_ibfk_1
        FOREIGN KEY (username)
            REFERENCES users (username)
);

INSERT INTO authorities(username, authority)
VALUES ('admin', 'ROLE_ADMIN'),
       ('user', 'ROLE_USER');
CREATE TABLE users
(
    username         VARCHAR(50)  NOT NULL,
    password         VARCHAR(100) NOT NULL,
    firstname        VARCHAR(30)  NOT NULL,
    lastname         VARCHAR(30)  NOT NULL,
    middlename       VARCHAR(30),
    dateofbirth      date         NOT NULL,
    address          VARCHAR(150),
    phonenumber      VARCHAR(14)  not null,
    inshurancenumber VARCHAR(16),
    photopath        varchar(250),
    enabled          boolean      NOT NULL,
    PRIMARY KEY (username),
    UNIQUE (username, inshurancenumber),
    UNIQUE (username, phonenumber)
);

INSERT INTO users(username, password, firstname, lastname, middlename, dateofbirth, address, phonenumber,
                  inshurancenumber, photopath, enabled)
VALUES ('admin', '$2a$10$j.Eqtb3PPM8bS9rew4Uu0Os26hu5g.9ouNoYo5IjhCAwKgMjUELFi', 'Дмитрий', 'Субботин', null,
        '2001-05-15'::date, 'Студенческий проезд 3а, кв.56', '+79128285795', '1234123412341234',
        'https://webuploads.hb.ru-msk.vkcs.cloud/default.jpg', true),
       ('user', '$2a$10$pmSqleuQX0M6hxYDQcd6P.CwHaix8gSxYiTU4pcZaOtDcz4pnb8em', 'Иван', 'Иванов', null,
        '2005-01-21'::date, 'Ленина  31, кв.23', '+79223334455', '3214222134552121',
        'https://webuploads.hb.ru-msk.vkcs.cloud/default.jpg', true),
       ('med', '$2a$10$e1XRyGPqPiyPvkYuCI/.du9BmcwJ239u4Z.Bg8YU26rjr8Ere6tbG', 'Семён', 'Сидоров', null,
        '1990-11-11'::date, 'Романа Ердякова  11, кв.53', '+79991211100', null,
        'https://webuploads.hb.ru-msk.vkcs.cloud/default.jpg', true);
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
       ('user', 'ROLE_USER'),
       ('med', 'ROLE_MED');

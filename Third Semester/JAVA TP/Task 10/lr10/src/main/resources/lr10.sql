CREATE DATABASE lab10;
CREATE TABLE students
(id serial NOT NULL PRIMARY KEY,
 name varchar(30) NOT NULL,
 PassportSerial varchar(4) not null,
 PassportNumber varchar(6) not null,
 UNIQUE (PassportSerial, PassportNumber)
);
CREATE TABLE subjects
(id serial NOT NULL PRIMARY KEY,
 name varchar(50) NOT NULL
);
CREATE TABLE progress
(id serial NOT NULL PRIMARY KEY,
 student int NOT NULL REFERENCES students(id) ON DELETE CASCADE,
 subject int NOT NULL REFERENCES subjects(id) ON DELETE CASCADE,
 mark smallint NOT NULL CHECK(mark BETWEEN 2 and 5)
);
--alter table students add constraint uniquePassport UNIQUE (PassportSerial, PassportNumber);

INSERT into students (id, name, PassportSerial, PassportNumber)
values
    (1, 'Вася', 3311, 435678),
    (2, 'Коля', 3322, 342345),
    (3, 'Петя', 3333, 123456),
    (4, 'Маша', 3344, 234567),
    (5, 'Даша', 3355, 345678),
    (6, 'Саша', 3366, 456789),
    (7, 'Лена', 3377, 567890),
    (8, 'Катя', 3388, 678901),
    (9, 'Оля', 3399, 789012),
    (10, 'Юля', 3300, 890123);

INSERT into subjects (id, name)
values
    (1, 'Математика'),
    (2, 'Русский язык'),
    (3, 'Физика'),
    (4, 'Химия'),
    (5, 'Биология'),
    (6, 'Информатика');

INSERT into progress (id, student, subject, mark)
values
    (1, 1, 1, 5),
    (2, 1, 2, 4),
    (3, 1, 3, 5),
    (4, 1, 4, 4),
    (5, 1, 5, 5),
    (6, 1, 6, 4),
    (8, 2, 2, 4),
    (9, 2, 3, 3),
    (10, 2, 4, 4),
    (11, 2, 5, 3),
    (12, 2, 6, 4),
    (13, 3, 1, 5),
    (14, 3, 2, 5),
    (15, 3, 3, 5),
    (17, 3, 5, 5),
    (18, 3, 6, 5),
    (19, 4, 1, 4),
    (20, 4, 2, 4),
    (21, 4, 3, 4),
    (22, 4, 4, 4),
    (24, 4, 6, 4),
    (27, 5, 3, 3),
    (28, 5, 4, 3),
    (29, 5, 5, 3),
    (30, 5, 6, 3),
    (31, 6, 1, 2),
    (32, 6, 2, 2),
    (33, 6, 3, 2),
    (34, 6, 4, 2),
    (35, 6, 5, 2),
    (36, 6, 6, 2);


Select distinct s.name from Students s
INNER JOIN Progress p
on s.id = p.student
inner join subjects ss
on ss.id = p.subject
WHERE p.mark = 3 or p.mark = 2
group by s.name;

select avg(p.mark) as "Средний балл" from progress p
inner join subjects s on p.subject = s.id
where s.name = 'Математика';

select avg(p.mark) as "Средний балл" from progress p
inner join subjects s on p.subject = s.id
inner join students s2 on p.student = s2.id
where s2.name = 'Даша';

SELECT count(*), s.name from progress p
inner join subjects s on s.id = p.subject
where p.mark > 2
group by s.name
order by count(*) desc limit 3;

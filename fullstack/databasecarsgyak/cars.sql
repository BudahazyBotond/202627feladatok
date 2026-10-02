CREATE TABLE IF NOT EXISTS `cars` (
    `id` int PRIMARY KEY auto_increment NOT NULL,
    `plate_number` VARCHAR(10) UNIQUE,
    `manufacturer` VARCHAR(20),
    `model` VARCHAR(20),
    `category` VARCHAR(5),
    `fuel` VARCHAR(10),
    `color` VARCHAR(10),
    `consumption` FLOAT
);

INSERT INTO `cars` (`plate_number`,`manufacturer`, `model`, `category`, `fuel`, `color`, `consumption`)
VALUES
('XXX-111', 'Opel', 'Adam', 'M1','benzin', 'piros', 5.1),
('AAA-555', 'Honda', 'Jazz', 'M1','hibrid', 'kék', 4.8),
('ABC-123', 'Ford', 'Focus', 'M1','diesel', 'kék', 4.7),
('AA-AX-1234', 'Ford', 'Fiesta', 'M1','benzin', 'sárga', 7.9)
;
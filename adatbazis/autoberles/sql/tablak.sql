CREATE DATABASE IF NOT EXISTS `autoberlesek`;
USE `autoberlesek`;

DROP TABLE IF EXISTS `berlesek`;
DROP TABLE IF EXISTS `autok`;
DROP TABLE IF EXISTS `ugyfelek`;

CREATE TABLE `autok` (
  `id` int NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `gyarto` varchar(10) DEFAULT NULL,
  `tipus` varchar(21) DEFAULT NULL,
  `szin` varchar(30) DEFAULT NULL,
  `loero` int DEFAULT NULL,
  `fogyasztas` float DEFAULT NULL
);

CREATE TABLE `ugyfelek` (
  `id` int NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `nem` varchar(15) DEFAULT NULL,
  `vnev` varchar(30) DEFAULT NULL,
  `knev` varchar(30) DEFAULT NULL,
  `irsz` int DEFAULT NULL,
  `varos` varchar(30) DEFAULT NULL,
  `cím` varchar(30) DEFAULT NULL,
  `szuletet` date DEFAULT NULL
);

CREATE TABLE `berlesek` (
  `auto_id` INT NOT NULL,
  `ugyfel_id` INT NOT NULL,
  `elvitte` DATETIME,
  `visszahozta` DATETIME DEFAULT NULL,
  FOREIGN KEY (`auto_id`) REFERENCES `autok`(`id`),
  FOREIGN KEY (`ugyfel_id`) REFERENCES `ugyfelek`(`id`)
);


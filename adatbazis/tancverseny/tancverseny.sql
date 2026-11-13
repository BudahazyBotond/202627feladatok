DROP DATABASE IF EXISTS tancverseny;
CREATE DATABASE tancverseny;
USE tancverseny;

DROP TABLE IF EXISTS Tanc;
DROP TABLE IF EXISTS Csoport;
DROP TABLE IF EXISTS Zene;

CREATE TABLE Csoport (
    CsoportID INT PRIMARY KEY AUTO_INCREMENT,
    Nev VARCHAR(255),
    Nemzetiseg VARCHAR(255),
    AtlagEletkor INT,
    ElertPontszam INT
);

CREATE TABLE Zene (
    Cim VARCHAR(255) PRIMARY KEY,
    Mufaj VARCHAR(255),
    Eloado VARCHAR(255)
);

CREATE TABLE Tanc (
    Nev VARCHAR(255),
    CsoportID INT,
    Cim VARCHAR(255),
    FOREIGN KEY (CsoportID) REFERENCES Csoport(CsoportID),
    FOREIGN KEY (Cim) REFERENCES Zene(Cim)
);
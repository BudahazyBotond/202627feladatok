USE tancverseny;

INSERT INTO Csoport (Nev, Nemzetiseg, AtlagEletkor, ElertPontszam) VALUES
('Bevándorlók', 'kárpátindiaiak', 22, 65),
('Fehérek', 'magyarok', 25, 88);

INSERT INTO Zene (Cim, Mufaj, Eloado) VALUES
('Kék Duna Keringő', 'keringő', 'Johann Strauss'),
('Csárdás', 'csárdás', 'Vittorio Monti');

INSERT INTO Tanc (Nev, CsoportID, Cim) VALUES
('Keringő', 2, 'Kék Duna Keringő'),
('Csárdás', 1, 'Csárdás'),
('Csárdás', 2, 'Csárdás');
-- 8. feladat
CREATE OR REPLACE VIEW `gyartok` AS
    SELECT DISTINCT `gyarto` FROM `autok` 
    ORDER BY `gyarto` DESC;

-- 9. feladat
SELECT * FROM `gyartok`;

-- 10. feladat
SELECT `gyarto`, `szin`, `loero` FROM `autok` 
WHERE (`loero` > 200 && `loero` <= 300) &&
((`gyarto` = 'BMW' || `gyarto` = 'Ford' || `gyarto` = 'Honda') &&
`szin` LIKE '%Kék%')
ORDER BY `loero` ASC;

-- 11. feladat
CREATE OR REPLACE VIEW `kintlevo` AS
    SELECT `autok`.`gyarto`, `autok`.`tipus`, `ugyfelek`.`vnev`, `ugyfelek`.`knev`, `berlesek`.`elvitte` FROM `berlesek` 
    JOIN `autok` ON `berlesek`.`auto_id` = `autok`.`id`
    JOIN `ugyfelek` ON `berlesek`.`ugyfel_id` = `ugyfelek`.`id`
    WHERE `berles`.`visszahozta` IS NULL;
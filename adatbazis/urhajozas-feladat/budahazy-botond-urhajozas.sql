

-- 2. feladat
CREATE DATABASE `urhajozas`
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;
-- 3. feladat
USE `urhajozas`;


-- 5. feladat
SELECT `nev`, `nem`, `szulev`
FROM `urhajos`;
-- 6. feladat
SELECT `megnevezes`, (DATEDIFF(DATE(`veg`), DATE(`kezdet`))) AS `nap`
FROM `kuldetes`;
-- 7. feladat
SELECT `nev`, (YEAR(NOW()) - `szulev`) AS `kor`
FROM `urhajos`
ORDER BY `kor` DESC;
-- 8. feladat
SELECT `kuldetes`.`megnevezes`, `urhajos`.`nev`
FROM `urhajos`
JOIN `repules` ON
    `repules`.`urhajos_id` = `urhajos`.`id`
JOIN `kuldetes` ON
    `kuldetes`.`id` = `repules`.`kuldetes_id` 
ORDER BY `kuldetes`.`kezdet` ASC,
    `urhajos`.`nev` ASC;
-- 9. feladat
SELECT `nev`, `szulev`
FROM `urhajos`
WHERE `nem` LIKE "N" AND `szulev` > 1960 AND `orszag` LIKE "CAN";
-- 10. feladat
SELECT `nev`
FROM `urhajos`
ORDER BY CHAR_LENGTH(`nev`) DESC
LIMIT 1;
-- 11. feladat
SELECT `megnevezes`, COUNT(*) AS `fo`
FROM `kuldetes`
JOIN `repules` ON
    `repules`.`kuldetes_id` = `kuldetes`.`id`
GROUP BY `kuldetes`.`megnevezes`;
-- 12. feladat
SELECT `nev`, COUNT(*) AS `db`
FROM `urhajos`
JOIN `repules` ON
    `repules`.`urhajos_id` = `urhajos`.`id`
GROUP BY `urhajos`.`nev`
HAVING `db` >= 6;
-- 13. feladat
SELECT ROUND(AVG(DATEDIFF(`veg`,`kezdet`)),2) AS `Gemini küldetések átlagos hosszúsága`
FROM `kuldetes`
WHERE `megnevezes` LIKE "Gemini%";
-- 14. feladat
SELECT `urhajos`.`orszag`
FROM `urhajos`
JOIN `repules` ON 
    `repules`.`urhajos_id` = `urhajos`.`id`
JOIN `kuldetes` ON 
    `kuldetes`.`id` = `repules`.`kuldetes_id`
WHERE YEAR(`kuldetes`.`kezdet`) > 1990 AND YEAR(`kuldetes`.`kezdet`) <= 2000
GROUP BY `urhajos`.`orszag`
ORDER BY COUNT(*) DESC
LIMIT 3;
-- 15. feladat
SELECT COUNT(*) AS `Robik száma`
FROM `urhajos`
WHERE `nev` LIKE "%Robert%";
-- 16. feladat
SELECT `nev`, `orszag`, `szulev`
FROM `urhajos`
WHERE `szulev` = (
    SELECT `szulev`
    FROM `urhajos`
    WHERE `nev` = "Barbara Morgan"
    LIMIT 1
);
-- 17. feladat

-- 18. feladat

-- 19. feladat

-- 20. feladat

-- 21. feladat
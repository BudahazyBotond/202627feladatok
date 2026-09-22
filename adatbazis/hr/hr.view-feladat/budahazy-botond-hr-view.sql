--3. feladat:
CREATE OR REPLACE VIEW `programozok` AS 
    Select CONCAT(`FIRST_NAME`,' ', `LAST_NAME`) AS `FULL_NAME`
    FROM `employees`
    JOIN `jobs`
        ON `jobs`.`JOB_ID` = `employees`.`JOB_ID`
    WHERE `jobs`.`JOB_TITLE` = 'Programmer';
--4. feladat:
SELECT * FROM `programozok`;
--5. feladat:
CREATE OR REPLACE VIEW `munkakorletszam` AS 
    Select `JOB_TITLE`, COUNT(employees.JOB_ID) AS `db`
    FROM `employees`
    JOIN `jobs`
        ON `jobs`.`JOB_ID` = `employees`.`JOB_ID`
    GROUP BY `jobs`.`JOB_TITLE`;
--6. feladat:
SELECT * FROM `munkakorletszam`
WHERE `db` >= 20;
--7. feladat:
CREATE OR REPLACE VIEW `orszagfo` AS 
    Select `COUNTRY_NAME`, COUNT(`employees`.`JOB_ID`) AS `fo`
    FROM `employees`
    JOIN `departments`
        ON `departments`.`DEPARTMENT_ID` = `employees`.`DEPARTMENT_ID`
    JOIN `locations`
        ON `locations`.`LOCATION_ID` = `departments`.`LOCATION_ID`
    JOIN `countries`
        ON `countries`.`COUNTRY_ID` = `locations`.`COUNTRY_ID`
    GROUP BY `COUNTRY_NAME`;
--8. feladat:
SELECT * FROM `orszagfo`;
--9. feladat:
CREATE OR REPLACE VIEW `reszlegvezeto` AS 
    Select `DEPARTMENT_NAME`, CONCAT(`FIRST_NAME`,' ', `LAST_NAME`) AS `FULL_NAME`
    FROM `departments`
    JOIN `employees`
        ON `employees`.`EMPLOYEE_ID` = `departments`.`MANAGER_ID`;
--10. feladat:
SELECT * FROM `reszlegvezeto`
WHERE `FULL_NAME` LIKE "Den%";
--11. feladat:
CREATE OR REPLACE VIEW `kihodolgozik` AS 
    Select CONCAT(`FIRST_NAME`,' ', `LAST_NAME`) AS `FULL_NAME`, `departments`.`DEPARTMENT_ID`, `departments`.`DEPARTMENT_NAME`
    FROM `employees`
    JOIN `departments`
        ON `departments`.`DEPARTMENT_ID` = `employees`.`DEPARTMENT_ID`;
--12. feladat:
SELECT ROUND(AVG(`employees`.`SALARY`)) as `atlag`
FROM `kihodolgozik`
JOIN `employees` ON `employees`.`DEPARTMENT_ID` = `kihodolgozik`.`DEPARTMENT_ID`
WHERE `FULL_NAME` = "David Austin";
--13. feladat:
CREATE OR REPLACE VIEW `belepo` AS 
    Select CONCAT(`FIRST_NAME`,' ', `LAST_NAME`) AS `FULL_NAME`, `employees`.`HIRE_DATE`
    FROM `employees`;
--14. feladat:
SELECT * FROM `belepo`;
--15. feladat:
CREATE OR REPLACE VIEW `regiovezetok` AS 
    Select CONCAT(`employees`.`FIRST_NAME`,' ', `employees`.`LAST_NAME`) AS `FULL_NAME`, `employees`.`HIRE_DATE`, `regions`.`REGION_NAME` 
    FROM `departments`
    JOIN `employees`
        ON `employees`.`EMPLOYEE_ID` = `departments`.`MANAGER_ID`
    JOIN `locations`
        ON `locations`.`LOCATION_ID` = `departments`.`LOCATION_ID`
    JOIN `countries`
        ON `countries`.`COUNTRY_ID` = `locations`.`COUNTRY_ID`
    JOIN `regions`
        ON `regions`.`REGION_ID` = `countries`.`REGION_ID`;
--16. feladat:
SELECT * FROM `regiovezetok`;
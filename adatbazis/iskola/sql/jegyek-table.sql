CREATE OR REPLACE TABLE `jegyek`(
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `tantargy_id` INT,
    `jegy` INT,
    `diak` VARCHAR(20),
    `tanar` VARCHAR(20),
    `beirva` DATETIME,
    FOREIGN KEY (`tantargy_id`)
        REFERENCES `tantargyak`(`id`)
);

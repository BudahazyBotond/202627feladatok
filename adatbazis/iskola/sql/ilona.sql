INSERT INTO `jegyek` (`tantargy_id`, `jegy`, `diak`, `tanar`, `beirva`)
VALUES (1, 5, "Juci", SUBSTRING_INDEX(USER(),"@",1), NOW());

INSERT INTO `jegyek` (`tantargy_id`, `jegy`, `diak`, `tanar`, `beirva`)
VALUES (2, 3, "Marci", SUBSTRING_INDEX(USER(),"@",1), NOW());

INSERT INTO `jegyek` (`tantargy_id`, `jegy`, `diak`, `tanar`, `beirva`)
VALUES (1, 4, "Kati", SUBSTRING_INDEX(USER(),"@",1), NOW());

-- UPDATE jegyek
-- SET jegy = 5
-- WHERE id = 3;
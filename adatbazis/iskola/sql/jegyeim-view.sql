-- 10. feladat
CREATE OR REPLACE VIEW `jegyeim` AS 
    SELECT *
    FROM `jegyek`
    WHERE `diak` = SUBSTRING_INDEX(USER(),"@",1); 
-- SUBSTRING_INDEX -> elvágja az 1. param stringet 2. param alapján a 3. param előfordulásnál

-- 
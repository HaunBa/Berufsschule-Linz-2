-- 1)
use bs2_mak;

-- 2)
SELECT 
	s.scja_name AS 'Schuljahr',
    COUNT(sc.per_id) AS 'Anzahl der Schueler'
FROM schuljahr s
INNER JOIN schuljahr_klasse sk ON s.scja_id = sk.scja_id
INNER JOIN schueler sc ON sk.sckl_id = sc.sckl_id
GROUP BY s.scja_name
ORDER BY s.scja_name;

-- 3)
SELECT 
	k.kla_name
FROM klasse k
LEFT JOIN schuljahr_klasse sk ON k.kla_id = sk.kla_id
WHERE sk.scja_id IS NULL;

-- 4)
SELECT 
	concat(p.per_vname, ' ', p.per_nname) AS 'Schueler 4.Klasse 2020/2021',
    k.kla_name AS 'Klasse'
FROM klasse k
LEFT JOIN schuljahr_klasse sk ON k.kla_id = sk.kla_id
LEFT JOIN schueler s ON sk.sckl_id = s.sckl_id
LEFT JOIN person p ON s.per_id = p.per_id
WHERE k.kla_name LIKE '4%'
AND sk.scja_id = 2
ORDER BY k.kla_name;

-- 5)
SELECT
	CONCAT(sj.scja_name, ' ', k.kla_name) AS 'SJ/Klasse',
    COUNT(p.per_id) AS 'Anzahl der Schueler'
FROM schuljahr sj
INNER JOIN schuljahr_klasse sk ON sj.scja_id = sk.scja_id
INNER JOIN klasse k ON sk.kla_id = k.kla_id
RIGHT JOIN schueler s ON sk.sckl_id = s.sckl_id
RIGHT JOIN person p ON s.per_id = p.per_id
GROUP BY CONCAT(sj.scja_name, ' ', k.kla_name)
ORDER BY CONCAT(sj.scja_name, ' ', k.kla_name) desc;

-- 6)
SELECT 
	CONCAT(p.per_vname, ' ', p.per_nname) AS 'Schüler*in ohne Schuljahrzuordnung'
FROM person P
LEFT JOIN schueler s ON p.per_id = s.per_id
LEFT JOIN schuljahr_klasse sk ON s.sckl_id = sk.sckl_id
WHERE sk.scja_id IS NULL;

-- 7)
-- a.
SELECT 
	k.kla_name AS 'Klasse',
    COUNT(sk.scja_id) AS 'Anzahl Schuljahre'
FROM klasse k
LEFT JOIN schuljahr_klasse sk ON k.kla_id = sk.kla_id
GROUP BY k.kla_name
ORDER BY k.kla_name;

-- b. 
SELECT 
	k.kla_name AS 'Klasse',
    COUNT(sk.scja_id) AS 'Anzahl Schuljahre'
FROM klasse k
LEFT JOIN schuljahr_klasse sk ON k.kla_id = sk.kla_id
GROUP BY k.kla_name
HAVING k.kla_name = '2aAPC'
ORDER BY k.kla_name;

-- c. 
SELECT 
	k.kla_name AS 'Klasse',
    COUNT(sk.scja_id) AS 'Anzahl Schuljahre'
FROM klasse k
LEFT JOIN schuljahr_klasse sk ON k.kla_id = sk.kla_id
GROUP BY k.kla_name
HAVING COUNT(sk.scja_id) > 1
ORDER BY k.kla_name;

-- 8)
SELECT * FROM person
WHERE per_vname LIKE '_er%'
OR per_nname LIKE '_er%';

-- 9)
SELECT 
	sj.scja_name AS 'Schuljahr',
    k.kla_name AS 'Klasse',
    CONCAT(p.per_nname, ' ', p.per_vname) AS 'Person'
FROM schuljahr sj
INNER JOIN schuljahr_klasse sk ON sj.scja_id = sk.scja_id
INNER JOIN klasse k ON sk.kla_id = k.kla_id
INNER JOIN schueler s ON sk.sckl_id = s.sckl_id
INNER JOIN person p ON s.per_id = p.per_id
ORDER BY sj.scja_name, k.kla_name, p.per_nname, p.per_vname;

-- 10)
SHOW CREATE TABLE schueler;

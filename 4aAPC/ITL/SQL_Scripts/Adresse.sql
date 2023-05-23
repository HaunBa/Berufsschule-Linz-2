/*
Haunschmied.Bastian, 16.05.23
Aufgabe Adresse
*/
use adresse;
-- Tabellen Anzeigen
show tables;

-- Alle Orte ausgeben
select * from ort;

-- Attribute Selektieren
-- a) nur Ortsnamen
select ort_name 
from ort;

-- b) Alle Personen ausgeben. per_nname | per_vname
select per_nname, per_vname
from person;

-- c) wie b) Attributalias
select per_nname as "Nachname", per_vname as "Vorname"
from person;

-- d) wie c) Tabellennamen explizit angeben
select 	person.per_nname as "Nachname", 
		person.per_vname as "Vorname"
from person;

-- e) Alle Datensätze (DS) aus Tabelle person_strasse_ort_plz ausgeben
select orpl_id, str_id, per_id
from person_strasse_ort_plz;

-- f) wie e) mit expliziter Angabe der Tabelle bei den Attributen
select person_strasse_ort_plz.orpl_id,
		person_strasse_ort_plz.str_id,
        person_strasse_ort_plz.per_id
from person_strasse_ort_plz;

/* 
	Aufgabe: 
    Ortsnamen mit e im Wortverlauf
    Personen deren Vorname an 2. Stelle ein a enthält
    Personen deren Nachname nicht auf r endet
*/
-- Ortsnamen mit e im Wortverlauf
select ort_name
from ort
where ort_name LIKE '%e%';

-- Personen deren Vorname an 2. Stelle ein a enthält
select per_vname, per_nname
from person
where per_vname LIKE '_a%';

-- Personen deren Nachname nicht auf r endet
select per_vname, per_nname
from person
where per_nname NOT LIKE '%r';


-- Inner JOIN
select plz_nr as "PLZ",
		ort_name as "Ort"
from 	ort_plz inner join (plz, ort) using (plz_id, ort_id);



-- 3) Anzahl der Personen die noch keiner Adresse zugeordnet wurden.

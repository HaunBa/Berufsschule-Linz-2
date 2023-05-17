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
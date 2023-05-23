use kurs;

show tables;

select * from person;

-- a) Geben Sie alle Kursteilnehmer eines bestimmten Kurses aus

SELECT p.per_vname as "Vorname", p.per_nname as "Nachname", k.kute_start "Start"
from person p
join buchung b on b.per_id = p.per_id
join kurstermin k on k.kute_id = b.kute_id
where k.kute_id = 3;

-- b) Anzahl der Teilnehmer je Kurs - sortiert nach Kursbezeichnung
SELECT 	k.kur_bezeichnung "Kurs",
		count(p.per_id) "Anzahl Personen"
FROM 	kurs k left outer join kurstermin kt on k.kur_id = kt.kur_id
		left outer join buchung b on b.kute_id = kt.kute_id
		left outer join person p on p.per_id = b.per_id
group by kur_bezeichnung;

-- c) Ermitteln Sie alle Kurse und führen Sie die Kursleiter ( Vortragenden ) an. Formatieren Sie das Datum (DATE_FORMAT)
-- Kursleiter, Kursbezeichnung, Beginn

SELECT 	CONCAT(p.per_vname, ' ' ,p.per_nname) as "Kursleiter", 
		k.kur_bezeichnung as "Kursbezeichnung", 
        date_format(kt.kute_start, "%M %d %Y") "Datum"
FROM kurstermin kt
JOIN person p on kt.vortragender_per_id = p.per_id
JOIN kurs k on kt.kur_id = k.kur_id;

-- d) Ermitteln Sie, wie viele Personen noch nie an einem Kurs teilgenommen haben

SELECT Count(p.per_id) "Personenanzahl"
-- select *
FROM person p
left outer join buchung b on p.per_id = b.per_id
where b.buc_id is null;

-- e) Ermitteln Sie, welche Personen einen bestimmten Kurs noch nicht besucht haben, sortiert nach Kurs, Personen.
SELECT CONCAT(p.per_vname, ' ' ,p.per_nname)
FROM person p;


-- f) Geben sie alle Kurse aus die mehr als 150 aber weniger als 2000 kosten
SELECT k.kur_bezeichnung "Kursbezeichnung",
		kp.kupr_wert "Preis"
FROM kurs k
join kurspreis kp on  k.kur_id = kp.kur_id
where kp.kupr_wert > 150 and kp.kupr_wert < 2000 and kp.kupr_bis > sysdate();

-- g) Geben Sie alle Personen aus, in deren Nachname an zweiter Stelle ein bestimmter Buchstabe steht
SELECT CONCAT(p.per_vname, " ", p.per_nname) "Nachname mit a an zweiter Stelle"
FROM person p
where p.per_nname like "_a%";

-- h) Geben Sie alle Personen aus deren Nachnamen mit einem bestimmten Buchstaben ( selber wählen ) beginnt nud deren Vorname auf einen bestimmten Buchstaben ( selber wählen ) endet
SELECT p.per_vname "Vorname", p.per_nname "Nachname"
FROM person p
where p.per_nname like "B%" and p.per_vname like "%a";

-- i) Geben Sie die Preisentwicklung zu einem bestimmten Kurs aus
SELECT 	ku.kur_bezeichnung "Kursbezeichnung", 
		kp.kupr_wert "Preis", 
        kp.kupr_bis "gültig bis"
FROM kurs ku
join kurspreis kp on kp.kur_id = ku.kur_id
where ku.kur_id = 1
order by kp.kupr_bis;

-- j) Geben Sie alle Personen nach Geschlecht, Nachnamen, und Vornamen sortiert aus. Wählen sie mind. einmal absteigend
SELECT p.per_geschlecht "Geschlecht",
		p.per_vname "Vorname",
		p.per_nname "Nachname"
FROM person p
order by p.per_geschlecht, p.per_vname, p.per_nname desc;

-- k) Welche Kurse finden in einem gewissen Zeitraum statt ( legen Sie den Zeitraum selber fest, z.B.: 1.10.08 bis 1.02.09)

SELECT 	ku.kur_bezeichnung "Bezeichnung",
		kt.kute_start "Startdatum"
from kurstermin kt
join kurs ku on kt.kur_id = ku.kur_id
where kt.kute_start between "2010-11-10" and "2021-12-08";

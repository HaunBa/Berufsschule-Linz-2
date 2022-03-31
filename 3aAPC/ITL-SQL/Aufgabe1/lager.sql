show databases;

use adresse;

show tables;

show create table plz;

select plz_nr from plz;

select plz_nr from plz
order by plz_id;

select * from plz where plz_nr = 4020 and ort_id is null;

select plz_nr as "PLZ",
		ort_name as "ORT",
		str_name as "Strasse"
		from ort natural join plz
			natural join plz_strasse
			natural join strasse
		order by plz_nr, ort_name
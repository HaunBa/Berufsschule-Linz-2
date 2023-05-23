<?php 
echo '<h2>Alle Adressen anzeigen </h2>';

$query1 = 'select 	plz_nr as "PLZ",
ort_name as "Ort",
str_name as "Strasse"
from strasse_ort_plz natural join ort_plz natural join strasse natural join ort
natural join plz;';

makeTable($query1);

echo '<h2 style="margin-top:100px;">Alle Personen mit vollständiger Adresse anzeigen</h2>';
// Aufgabe: Alle personen mit Adresse in Tabelle ausgeben

$query2 = 'select 	per_vname as "Vorname",
per_nname as "Nachname",
plz_nr as "PLZ",
ort_name as "Ort",
str_name as "Strasse"
from person natural join person_strasse_ort_plz
natural join strasse_ort_plz natural join strasse
natural join ort_plz natural join ort natural join plz;';

makeTable($query2);


?>
show databases;
use immobilie;

select o.obj_id "ObjektNr",
	   oa.obar_name "Objekt Art",
       pr.pre_betrag "Preis",
       concat(pl.plz_id, ' ',  ort.ort_name, ', ', o.obj_strasse_nr) "Anschrift",
       l.land_name "Land"
from objekt o
left join objektart oa on o.obar_id = oa.obar_id
left join preis pr on o.obj_id = pr.obj_id
left join plz pl on o.plz_id = pl.plz_id
left join ort ort on pl.ort_id = ort.ort_id
left join land l on l.land_id = ort.land_id;
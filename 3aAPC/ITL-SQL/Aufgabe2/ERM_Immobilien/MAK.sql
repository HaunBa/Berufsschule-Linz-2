use party;

-- Auswahl aller Gerichte aller Gäste

select 
	concat(g.gast_vname, g.gast_nname) as 'Gast',
	v.vosp_name as 'Vorspeise',
    h.hasp_name as 'Hauptspeise',
    case
    when men_beilagensalat is null then 'keinen'
    when men_beilagensalat = 1 then 'ja'
    when men_beilagensalat = 0 then 'nein'
    end as beilagensalat,
    n.nasp_name as 'Nachspeise'
    from menuewahl men
    left join gast g on men.gast_id = g.gast_id
    left join vorspeise v on men.vosp_id = v.vosp_id
    left join hauptspeise h on men.hasp_id = h.hasp_id
    left join nachspeise n on men.nasp_id = n.nasp_id;
    
    
-- Welche Gäste noch keine Speise gewählt haben

select concat(gast_vname, " ", gast_nname) "Gast ohne Menue"
from gast
left join menuewahl using (gast_id)
where mewa_id is null;

-- Welches Hauptgericht wurde noch nicht gewählt

select hasp_name "Hauptgericht"
from hauptspeise
left join menuewahl using (hasp_id)
where mewa_id is null;

-- Wie oft wurden einzelne Hauptgerichte gewählt
select hasp_name "Hauptspeise", count(*) "x mal gewaehlt"
from hauptspeise h
join menuewahl using (hasp_id)
group by hasp_name;

-- welches gericht wurde mehr als 1x gewählt
select hasp_name "Hauptgericht", count(*) "x mal gewaehlt"
from hauptspeise
join menuewahl using (hasp_id)
group by hasp_name
having (count(*)>1);

-- Was kosten die Gerichte vom Gast mit der ID 1
select sum(hasp_preis + vosp_preis + nasp_preis) "Gesamtpreis"
from gast
join menuewahl using(gast_id)
join hauptspeise using (hasp_id)
join vorspeise using (vosp_id)
join nachspeise using (nasp_id)
where gast_id = 1;

-- Gesamtpreis je gast

select concat(gast_vname, " ", gast_nname) "Gast",
sum(vosp_preis + hasp_preis + nasp_preis) "Gesamtpreis"
from gast
left join menuewahl using(gast_id)
left join vorspeise using (vosp_id)
left join hauptspeise using (hasp_id)
left join nachspeise using (nasp_id)
group by gast_nname;

-- Welcher Gast hat die höchsten Kosten

select concat(gast_vname, " ", gast_nname) "Gast",
sum(vosp_preis + hasp_preis + nasp_preis) "Gesamtpreis"
from gast
left join menuewahl using(gast_id)
left join vorspeise using (vosp_id)
left join hauptspeise using (hasp_id)
left join nachspeise using (nasp_id)
group by gast_nname
order by Gesamtpreis desc
limit 1;

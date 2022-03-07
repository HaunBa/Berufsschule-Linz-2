show databases;
use schule;
show tables;

select * from schueler;
describe schueler;

show create table schueler_has_beruf;

select concat(per_vname, ' ', per_nname, ' ',idschueler) as "Schueler" from schueler;

select concat(' ',per_vname, per_nname) as "Person", ber_name as "Beruf" from schueler s, schueler_has_beruf shb, beruf b 
where s.idschueler = shb.schueler_per_id
and b.ber_id = shb.beruf_ber_id
order by Beruf;

select concat_ws(' ', sch_vname, sch_nname)as "Person",
	ber_name as "Beruf"
from person p inner join person_has_beruf phb
				on p.per_id = phb.person_per_id
                inner join beruf b
                on b.ber_id = phb.beruf_ber_id;

select ber_name as "Beruf",
	count(idschueler) as "Anzahl Personen"
from schueler_has_beruf phb inner join beruf b on b.ber_id = phb.beruf_ber_id
group by Beruf;

insert into schueler (per_vname, per_nname) values("Erna", "Baum");
insert into schueler_has_beruf values(3,1);
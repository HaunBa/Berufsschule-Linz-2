show databases;

use hersteller;

select *
from artikel left outer join artikel_has_hersteller using(art_id)
where her_id is null;

select *
from artikel
where art_id not in
(select art_id from artikel_has_hersteller);

select her_name
from hersteller
where her_id not in (select her_id from artikel_has_hersteller);

-- natural join

select art_name, her_name
from artikel_has_hersteller natural join (hersteller, artikel);
-- use correct databases
show databases;
use MeetingApp;

select u.Uhrzeit_Datum_Beignn, u.Uhrzeit_Datum_Ende, fa.vname, fa.nname, k.Kilometerstand_Beginn, k.Kilometerstand_Ende 
from fahrt f
join uhrzeit u on f.uhrzeit_id = u.Id
join fahrer fa on f.fahrer_id = fa.Id
join kilometerstand k on f.kilometerstand_id = k.Id
join auto a on f.auto_id = a.Id;
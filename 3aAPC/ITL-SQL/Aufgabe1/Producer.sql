show databases;

use business;

show tables;

-- a)
select * from producer;

-- b)
show fields from producer;

-- c)
show create table article_producer;

-- d)
select * from producer order by pro_name ASC;

-- e)
-- InnerJoin

select art.art_name as "Artikel", pro.pro_name as "Herstellerbezeichnung"
from article art inner join article_producer artpro
on art.art_id = artpro.art_id
inner join producer pro
on pro.pro_id = artpro.pro_id
order by pro.pro_name desc, art.art_name;
-- natural join
select article.art_name as "Artikel", producer.pro_name as "Herstellerbezeichnung"
from article natural join article_producer natural join producer
order by producer.pro_name desc, article.art_name;
-- equi join
select art.art_name "Artikel", pro.pro_name "Herstellerbezeichnung"
from article art, article_producer artpro, producer pro
where art.art_id = artpro.art_id
and pro.pro_id = artpro.pro_id
order by pro.pro_name desc, art.art_name;



-- f)
select pro.pro_name "Hersteller", art.art_name "Artikel", art.art_price "Price"
from article art natural join article_producer natural join producer pro;
-- g)
select pro.pro_name "Hersteller", art.art_name "Artikel", art.art_price "Price"
from article art natural join article_producer natural join producer pro
limit 2,1;



-- h)
select pro.pro_name "Hersteller", art.art_name "Artikel"
from article art left join article_producer artpro
on art.art_id = artpro.art_id
left join producer pro
on pro.pro_id = artpro.pro_id
order by pro.pro_name desc, art.art_name;

-- i)
select pro.pro_name "Hersteller", count(art.art_id) as "Anzahl Artikel"
from article art natural join article_producer artpro natural join producer pro
group by pro.pro_name;

-- j)
select pro.pro_name "Hersteller", count(art.art_id) as "Anzahl Artikel"
from article art right join article_producer artpro
on art.art_id = artpro.art_id
right join producer pro
on pro.pro_id = artpro.pro_id
group by pro.pro_name;

-- k)

select distinct(pro.pro_name) as "Hersteller"
from article art natural join article_producer artpro natural join producer pro;

-- l)
select count(*) as 'Anzahl Artikel'from article;

-- m)
select *
from producer
where pro_id not in(select pro_id from article_producer); 

show databases;
select business;
show tables;
-- n)
select pro_name
from producer
WHERE pro_id in (select pro_id FROM article_producer GROUP BY pro_id HAVING Count(*)> 1) ;

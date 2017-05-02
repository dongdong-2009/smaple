/* logtest : ip, t时间*/

drop table #t_ips

select * from #t_ips

select distinct ip,datepart(hh,t) as hour,datepart(mi,t) as min
into #t_ips
from logtest

delete from #t_ips 
where min >= 30
and exists(select * from #t_ips a
where a.hour = #t_ips.hour and a.min < 30 and a.min > #t_ips.min - 30
and a.ip = #t_ips.ip)

delete from #t_ips 
where min < 30
and exists(select * from #t_ips a
where a.hour = #t_ips.hour - 1 and a.min > 30 and a.min > #t_ips.min + 30
and a.ip = #t_ips.ip)

select count(*) from (
select distinct ip,hour,case when min >= 30 then 1 else 0 end as hfpart
from #t_ips
)z


select datepart(hh,'2012-1-1 11:12')

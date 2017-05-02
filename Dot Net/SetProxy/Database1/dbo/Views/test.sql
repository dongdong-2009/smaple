CREATE view [dbo].[test] as  
select team,m,[no] from (  
select a.hometeam+'vs'+a.awayteam as team, case when 100*a.win/b.win > 100 then '上盘形成超级热。上盘升盘并为相对中低水才有胜出。'   
when 100*a.win/b.win > 93 and 100*a.draw/b.draw <89 and 100*a.lose/b.lose <89 then '主队大热对于舆论大热的上盘必须极低水才能胜出；或者舆论不热，若开中水深盘并缓慢降到中低水亦可胜出，其余一概不胜。'  
when 100*a.win/b.win > 91 and 100*a.draw/b.draw >91 and 100*a.lose/b.lose <89 then '主队不败，此时舆论过热上盘不升盘或不极低水出平局，舆论不热上盘用低水，或升盘必定胜出。'  
when 100*a.win/b.win < 91 AND a.draw/b.draw > a.win/b.win and a.draw/b.draw >a.lose/b.lose then '劣势盘，半一或半球，必定上盘不出，若是平半，舆论热或正常情况不出；若舆论大冷，则用低水可胜出。'  
when a.lose/b.lose > a.win/b.win and a.lose/b.lose >a.draw/b.draw then '投注上半场下盘'  
when 100*a.win/b.win > 91 and 100*a.draw/b.draw >91 and 100*a.lose/b.lose >91 and a.draw/b.draw < a.win/b.win and  a.draw/b.draw <a.lose/b.lose then '主客盘形成对冲局面'  
when 100*a.win/b.win > 91 and 100*a.draw/b.draw >91 and 100*a.lose/b.lose >91 then '此时对战的舆论和基本面较强势的一方为不利。均势盘：被欧赔亚盘热捧一方不出。'  
else 'error' end as m,a.matchnumber as [no]  
 from vCurrentEuropePan a inner join vCurrentEuropePan b  
on a.matchid = b.matchid and a.companyid = 115 and b.companyid = 2 and a.pantype =b.pantype  
where a.pantype ='初盘' and a.win >0 and b.win > 0 and a.draw >0 and b.draw >0 and a.lose >0 and a.lose >0  
and a.win < b.win and a.draw < b.draw and a.lose <b.lose
) as c  
where c.m <>'error' 
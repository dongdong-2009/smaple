


CREATE PROCEDURE [dbo].[sp_CreateReturnRate]    
AS
BEGIN    
delete from Forecast where [type] like '%ReturnRate%' and termindex = (select top 1 termindex from currentmatch)  
--初盘  
select min(returnrate) as [min],max(returnrate) as [max],companyid,leaguename into #chupanTmp from vcurrenteuropepan  
where companyid in(0,80,81,82,115,432)  and pantype ='初盘'  
and   
(  
 select count(1) from currentmatch c1 where leaguename=vcurrenteuropepan.leaguename   
 and exists  
 (select * from currentpan where matchid = c1.matchid and companyid = vcurrenteuropepan.companyid)  
) >= 5--比赛大于5场  
group by leaguename,companyname,companyid  
  
--min  
 insert into Forecast(matchid,type,description,termindex)    
select distinct matchid,'ReturnRate',b.companyname+'- min 初盘 ' + CAST( a.min as varchar(10)) ,termindex from #chupanTmp a inner join vcurrenteuropepan b   
on a.companyid = b.companyid and a.leaguename = b.leaguename and a.[min] = b.returnrate   
where  b.pantype = '初盘'  and ((b.win > b.draw and b.win > b.lose) or (b.lose > b.draw and b.lose > b.win) )


--max  
 insert into Forecast(matchid,type,description,termindex)    
select distinct matchid,'ReturnRate',b.companyname+'- MAX 初盘 ' + CAST( a.max as varchar(10)) ,termindex  from #chupanTmp a inner join vcurrenteuropepan b   
on a.companyid = b.companyid and a.leaguename = b.leaguename and a.[max] = b.returnrate   
where  b.pantype = '初盘'   and ((b.win > b.draw and b.win > b.lose) or (b.lose > b.draw and b.lose > b.win) )

--temp
select *,'受注盘' as pantype  into #temp  from 
(select row_number()over(partition by leaguename,matchid,companyid order by createtime desc) as num   
,leaguename ,companyname,matchid,companyid,returnrate,termindex,win,draw,lose
from vcurrenteuropepan  where pantype ='受注盘'  
)a where a.num = 1 

  
--终盘  
select leaguename ,companyid,min(returnrate) as [min],max(returnrate) as [max] into #finalpanTmp from #temp b
where companyid in(0,80,81,82,115,432)
and (  
select count(1) from currentmatch c1 where leaguename=b.leaguename   
 and exists  
 (select * from currentpan where matchid = c1.matchid and companyid = b.companyid)  
  
) >= 5--比赛大于5场  
group by leaguename,companyid  
  
--min  
 insert into Forecast(matchid,type,description,termindex)    
select distinct matchid,'ReturnRate',b.companyname+'- min 终盘 ' + CAST( a.min as varchar(10)) ,termindex   from #finalpanTmp a inner join #temp b   
on a.companyid = b.companyid and a.leaguename = b.leaguename and a.[min] = b.returnrate   
where  b.pantype = '受注盘'   and ((b.win > b.draw and b.win > b.lose) or (b.lose > b.draw and b.lose > b.win) )

  
--max  
 insert into Forecast(matchid,type,description,termindex)    
select distinct matchid,'ReturnRate',b.companyname+'- MAX 终盘 ' + CAST( a.max as varchar(10)) ,termindex   from #finalpanTmp a inner join #temp b   
on a.companyid = b.companyid and a.leaguename = b.leaguename and a.[max] = b.returnrate   
where  b.pantype = '受注盘'   and ((b.win > b.draw and b.win > b.lose) or (b.lose > b.draw and b.lose > b.win) )

  
--删除临时表  
drop table #chupanTmp  
drop table #finalpanTmp  
drop table #temp
end



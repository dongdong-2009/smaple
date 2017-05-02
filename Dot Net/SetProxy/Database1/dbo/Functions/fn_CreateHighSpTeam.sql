CREATE  function fn_CreateHighSpTeam  
(  
 @leaguename  varchar(12)  
)  
RETURNS  table as   
return  
 select top 4 team from (  
 select sum(scoresp)/sum([count]) as scoresp,team  from (  
 select  sum(scoresp) as scoresp,count(1) as [count],hometeam as team from historymatch where leaguename =@leaguename and scoresp>0  
 group by hometeam  
 union all  
 select  sum(scoresp) as scoresp,count(1) as [count],awayteam as team from historymatch where leaguename =@leaguename and scoresp>0  
 group by awayteam  
 ) a  
 group by team  
 ) b   
 order by scoresp desc  
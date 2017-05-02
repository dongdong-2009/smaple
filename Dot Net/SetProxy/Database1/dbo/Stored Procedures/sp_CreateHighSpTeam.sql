 
CREATE PROCEDURE [dbo].[sp_CreateHighSpTeam]    
AS
BEGIN    
 --truncate table HighSPTeam    
 --insert into HighSPTeam(leaguename,teamname)    
 --select a.leaguename,b.team from (    
 --select leaguename from CurrentMatch group by leaguename    
 --) a cross apply dbo.fn_CreateHighSpTeam(a.leaguename) b    
     
--delete from Forecast where type='高SP'  and termindex =(select top 1 termindex from currentmatch)  
delete from forecast where type like '%球队信息%'  
delete from forecast where type like '%球队概况%'  
-- insert into Forecast(matchid,type,description,termindex)    
-- select distinct b.matchid,a.type,  
-- case when a.auto = 0 or a.type ='高SP' then a.teamname+'-'+a.description else a.description end,   
--b.termindex from v_TeamInformation a inner join currentmatch b    
-- on --(b.hometeam like  '%' + a.teamname +'%'  ) or (b.awayteam like  '%' + a.teamname +'%'  ) or (a.teamname like  '%' + b.awayteam  +'%' ) or (a.teamname like  '%' + b.hometeam  +'%')   
--    b.hometeam like '%'+ a.description+'%' or b.awayteam like '%'+ a.description+'%' 


-- insert into Forecast(matchid,type,description,termindex)    
-- select distinct b.matchid,'高SP',  teamname,   
--b.termindex from highspteam a inner join currentmatch b    
-- on (b.hometeam like  '%' + a.teamname +'%'  ) or (b.awayteam like  '%' + a.teamname +'%'  ) or (a.teamname like  '%' + b.awayteam  +'%' ) or (a.teamname like  '%' + b.hometeam  +'%')   
    
insert into Forecast(matchid,type,description,termindex,Remark)    
select distinct b.matchid,'球队信息', teamname +'\r\n' +  description, b.termindex,a.createtime
from team_information a inner join currentmatch b 
on a.teamname like '%'+b.hometeam+'%' or a.teamname like '%'+b.awayteam+'%' 
where a.auto = 1 

insert into Forecast(matchid,type,description,termindex,Remark)    
select distinct b.matchid,'【球队概况】', a.teamname + ' ' + description, b.termindex , GETDATE()
from team_information a inner join currentmatch b 
on (a.teamname like '%'+b.hometeam+'%' or a.teamname like '%'+b.awayteam+'%' )  or (b.hometeam like '%'+a.teamname+'%' or b.awayteam like '%'+a.teamname+'%' ) 
where a.auto = 0
END

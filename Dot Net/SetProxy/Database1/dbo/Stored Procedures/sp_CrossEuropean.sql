

CREATE PROCEDURE [dbo].[sp_CrossEuropean]      
AS
BEGIN      
delete from Forecast where [type] like '%交叉%' and termindex = (select top 1 termindex from currentmatch)    
--正交叉盘   
insert into Forecast(matchid,companyid,[type],description,termindex)  
select v1.matchid,v1.companyid,'交叉盘', cast(v2.matchnumber as varchar(10))+'.'+ v2.hometeam+'VS'+v2.awayteam ,v1.termindex  from vcurrenteuropepan v1 inner join vcurrenteuropepan v2  
on v1.leaguename = v2.leaguename and v1.companyid=v2.companyid and v1.panid <> v2.panid  
and v1.win = v2.win and v1.draw = v2.draw and v1.lose =v2.lose and v1.pantype = v2.pantype   and v1.matchid <> v2.matchid
where v1.pantype = '初盘'   
--反交叉盘  
--insert into Forecast(matchid,companyid,[type],description,termindex)  
--select v1.matchid,v1.companyid,'【反交叉盘】',  cast(v2.matchnumber as varchar(10))+'.'+ v2.hometeam+'VS'+v2.awayteam,v1.termindex  from vcurrenteuropepan v1 inner join vcurrenteuropepan v2  
--on v1.leaguename = v2.leaguename and v1.companyid=v2.companyid and v1.panid <> v2.panid  
--and v1.win = v2.lose and v1.draw = v2.draw and v1.lose =v2.win and v1.pantype = v2.pantype   and v1.matchid <> v2.matchid
--where v1.pantype = '初盘'   
end


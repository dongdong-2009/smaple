CREATE VIEW [dbo].[vCurrentAsiaPan] AS   
select a.matchid,a.termindex,c.companyname,a.pantype,a.createtime,a.beforematchtime,  
a.win, a.lose,a.[win_upordown], a.[lose_upordown],  
d.[HomeTeam],d.[AwayTeam],d.[LeagueName],d.[LetBall],d.matchtime,d.matchnumber,a.companyid ,a.pankou ,a.panid 
from currentAsiapan a   
inner join Asiacompany c  
on a.companyid = c.companyid  
inner join CurrentMatch d  
on a.termindex = d.termindex and a.matchid = d.matchid;  

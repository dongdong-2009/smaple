CREATE VIEW [vCurrentEuropePan] AS   
select a.matchid,a.termindex,c.companyname,a.pantype,a.createtime,a.beforematchtime,  
b.win,b.draw,b.lose,b.[win_upordown],b.[draw_upordown],b.[lose_upordown],b.returnrate,  
d.[HomeTeam],d.[AwayTeam],d.[LeagueName],d.[LetBall],d.matchtime,d.matchnumber,a.companyid  ,a.panid 
from currentpan a inner join currenteuropepan b  
on a.panid = b.panid  
inner join company c  
on a.companyid = c.companyid  
inner join CurrentMatch d  
on a.termindex = d.termindex and a.matchid = d.matchid;  
  
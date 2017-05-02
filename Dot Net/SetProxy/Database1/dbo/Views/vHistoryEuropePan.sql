CREATE VIEW [vHistoryEuropePan] AS 
select a.matchid,a.termindex,c.companyname ,a.createtime, 
b.win,b.draw,b.lose,b.[win_upordown],b.[draw_upordown],b.[lose_upordown],b.returnrate,
d.[HomeTeam],d.[AwayTeam],d.[LeagueName],d.[LetBall],d.[Score],d.result,a.pantype,a.[BeforeMatchTime],a.companyid,d.matchnumber
from historypan a inner join historyeuropepan b
on a.panid = b.panid
inner join company c
on a.companyid = c.companyid
inner join HistoryMatch d
on a.termindex = d.termindex and a.matchid = d.matchid;


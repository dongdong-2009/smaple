  
    
CREATE PROCEDURE [dbo].[sp_UpdateReturnRate]    
AS    
BEGIN    
    
truncate table ReturnRate    
    
insert into ReturnRate(companyid,leaguename,begin_maxreturn,begin_minreturn,begin_avgreturn)    
select companyid,leaguename,max(returnrate) as begin_maxreturn,min(returnrate) as begin_minreturn,avg(returnrate) as begin_avgreturn   
from   
(  
select b.returnrate,d.[LeagueName],a.pantype,a.companyid   
from historypan a inner join historyeuropepan b    
on a.panid = b.panid    
inner join HistoryMatch d    
on a.termindex = d.termindex and a.matchid = d.matchid  
where pantype = '初盘' and returnrate <99.9 )  xx   
group by  companyid,leaguename  
having COUNT(1) > 55  
  
END    
     
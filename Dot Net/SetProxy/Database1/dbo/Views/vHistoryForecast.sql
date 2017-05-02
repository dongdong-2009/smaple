        
CREATE VIEW [dbo].[vHistoryForecast] AS        
select        
  forecastid,        
  m.[Result] 赛果,        
  m.[Score] 比分,          
  a.[Type] 类型,        
  a.[BeforeMatchTime] 距离比赛开始时间,         
  a.[Description] 说明,         
  a.[TermIndex],         
  a.[Win],         
  a.[Draw],         
  a.[Lose],               
  m.hometeam +'-'+m.[awayteam] 对阵,          
  b.hometeam +'-'+b.[awayteam] 历史对阵,          
  m.matchnumber 场次,          
  c.companyname 公司,          
  m.letball 让球,          
  m.leaguename 联赛,            
m.matchtime ,        
 iscorrect,a.matchid        
  from forecast a        
inner join historymatch m        
on a.matchid = m.matchid and a.termindex = m.termindex        
left join historymatch b on        
a.oldmatchid = b.matchid         
left join vAllCompany c        
on a.companyid = c.companyid; 
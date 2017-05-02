
        
CREATE VIEW [dbo].[vGetForeCast] AS                         
--select cast(b.result as varchar(2)) as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵',                       
--b.Score as '比分',a.letball as '让球', a.matchtime as '时间',                      
--a.[MatchNumber] as '场次',a.companyname as '公司',b.pantype as  '类型',                     
--'' as '说明',b.beforematchtime as '距离比赛时间',a.win as 'win',a.draw as 'draw',a.lose as 'lose',b.[MatchID] as 'OldMatchId',a.matchid,a.companyid,a.termindex,                                                                                    
--b.[HomeTeam] +'-'+b.awayteam  as '历史对阵'                            
--from vCurrentEuropePan a inner join vhistoryeuropepan b                      
--on  a.companyid = b.companyid and a.win = b.win and b.draw = a.draw and a.lose = b.lose and a.pantype = b.pantype                     
--where b.win <> 1 and b.[draw] <>1 and b.lose <> 1                            
--and a.leaguename = b.leaguename                        
--and ( b.pantype='初盘')                         
--and a.hometeam = b.hometeam                      
--and a.letball = b.letball                      
--and b.score!='*'                         
--and (select count(1) from vforecast where vforecast.termindex = a.termindex and 类型='初盘') =0                        
--union all                        
--select b.result as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵',                     
--b.[Score] as '比分',b.[LetBall] as '让球', a.[MatchTime] as '时间',                     
--a.[MatchNumber] as '场次','' as '公司','平均欧赔-同联赛' as  '类型',                     
--'' as '说明','' as '距离比赛时间',a.win as 'win',a.draw as 'draw',a.lose as 'lose',b.matchid as 'OldMatchId',a.matchid,'' as companyid,a.termindex,                                                                                    
--b.[HomeTeam] +'-'+b.awayteam as '历史对阵'                                                                                    
-- from currentmatch a inner join historymatch b                       
--on a.leaguename = b.leaguename and  a.win = b.win and b.draw = a.draw and a.lose = b.lose and a.letball= b.letball                       
--where b.win <> 1 and b.[draw] <>1 and b.lose <> 1 and b.score!='*'                                  
--union all                         
--select b.result as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵',                      
--b.[Score] as '比分',b.[LetBall] as '让球', a.[MatchTime] as '时间',                     
--a.[MatchNumber] as '场次','' as '公司','平均欧赔-同主队' as  '类型',                    
--'' as '说明','' as '距离比赛时间',a.win as 'win',a.draw as 'draw',a.lose as 'lose',b.matchid as 'OldMatchId',a.matchid,'' as companyid,a.termindex,                                                                                    
--b.[HomeTeam] +'-'+b.awayteam as '历史对阵'                        
-- from currentmatch a inner join historymatch b                     
--on a.win = b.win and b.draw = a.draw and a.lose = b.lose and a.hometeam = b.hometeam and a.letball= b.letball and b.score!='*'                        
--where b.win <> 1 and b.[draw] <>1 and b.lose <> 1                        
--union all                                     
--select b.result as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵',                         
--b.[Score] as '比分',b.[LetBall] as '让球', a.[MatchTime] as '时间',                     
--a.[MatchNumber] as '场次','' as '公司','平均欧赔-同主客' as  '类型',                     
--'' as '说明','' as '距离比赛时间',a.win as 'win',a.draw as 'draw',a.lose as 'lose',b.matchid as 'OldMatchId',a.matchid,'' as companyid,a.termindex,                                                          
--b.[HomeTeam] +'-'+b.awayteam as '历史对阵'                         
-- from currentmatch a inner join historymatch b                     
--on a.win = b.win and b.draw = a.draw and a.lose = b.lose and a.hometeam = b.hometeam and a.awayteam = b.awayteam and a.letball= b.letball                                                                                   
  --where b.win <> 1 and b.[draw] <>1 and b.lose <> 1 and b.score!='*'                       
--union all                                              
--                                        
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵',                      
--'' as '比分','' as '让球', a.[MatchTime] as '时间',                                                                
--a.[MatchNumber] as '场次',c.companyname as '公司','经典盘' as  '类型',                                                                          
--b.description as '说明','' as '距离比赛时间',a.win as 'win',a.draw as 'draw',a.lose as 'lose',null as 'OldMatchId',a.matchid,c.companyid,a.termindex,                                        
--null as '历史对阵'                          
-- from vcurrenteuropepan a inner join ClassicPan b                                                                                     
--on a.win = b.win and b.draw = a.draw  and a.lose = b.lose  and a.companyid = b.companyid                                                                                    
--inner join company c                                                                                     
--on b.companyid = c.companyid                                                                                    
--union all                                                                                    
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵',                                                                                  
--'' as '比分','' as '让球', a.[MatchTime] as '时间',                                                                                    
--a.[MatchNumber] as '场次',a.companyname as '公司','胜平相等' as  '类型',                                                                                    
--'' as '说明','' as '距离比赛时间',a.win as 'win',a.draw as 'draw',a.lose as 'lose',null as 'OldMatchId',a.matchid,a.companyid,a.termindex,                                                                                    
--null as '历史对阵'                                                                                    
-- from vcurrenteuropepan  a                                                                                    
--where (win=draw)                                                                                    
--and pantype='初盘'                                                                                    
--union all                                                                                    
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵',                                                                                    
--'' as '比分','' as '让球', a.[MatchTime] as '时间',                                                                                    
--a.[MatchNumber] as '场次',a.companyname as '公司','胜负相等' as  '类型',                                                                                    
--'' as '说明','' as '距离比赛时间',a.win as 'win',a.draw as 'draw',a.lose as 'lose',null as 'OldMatchId',a.matchid,a.companyid,a.termindex,                                                                             
--null as '历史对阵'                                             
-- from vcurrenteuropepan  a                                                                                    
--where (win = lose )                                                                              
--and pantype='初盘'                                                         
--union all                                                                                    
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵',                                                                                    
--'' as '比分','' as '让球', a.[MatchTime] as '时间',                                                                                    
--a.[MatchNumber] as '场次',a.companyname as '公司','平负相等' as  '类型',       
--'' as '说明','' as '距离比赛时间',a.win as 'win',a.draw as 'draw',a.lose as 'lose',null as 'OldMatchId',a.matchid,a.companyid,a.termindex,                                                                                   
--null as '历史对阵'                                                                     
-- from vcurrenteuropepan  a                     
--where (draw = lose )                                                                                    
--and pantype='初盘'                                                                        
--                                                                                    
--union all                                                                           
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                    
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
--,a.[MatchNumber] as '场次','' as '公司','非标准赔率' as  '类型'                                                                                    
--,'低赔Oddset大于威廉' as '说明','' as '距离比赛时间',0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',a.matchid,'' as companyid,a.termindex                                                    
--,null as '历史对阵'                                                                                     
-- from vcurrenteuropepan a inner join vcurrenteuropepan b                                                                                     
--on a.termindex = b.termindex and a.matchid = b.matchid                                                                                    
--where a.companyid=370 and b.companyid=151                                                                                    
--and a.win < a.draw and a.draw < a.lose and b.win < b.draw and b.draw < b.lose                                                                                    
--and a.win > b.win                                                                                    
--union all                                                                                    
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                            
--,a.[MatchNumber] as '场次','' as '公司','非标准赔率' as  '类型'                                                                                    
--,'低赔Oddset大于威廉' as '说明','' as '距离比赛时间',0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',a.matchid,'' as companyid,a.termindex                                                                                    
--,null as '历史对阵'                                                                              
-- from vcurrenteuropepan a inner join vcurrenteuropepan b                                                                                     
--on a.termindex = b.termindex and a.matchid = b.matchid                                                                                    
--where a.companyid=370 and b.companyid=151                                                                            
--and a.win > a.draw and a.draw > a.lose and b.win > b.draw and b.draw > b.lose                                                                                    
--and a.lose > b.lose                                                                                    
--union all                                                                                    
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                             
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                    
--,a.[MatchNumber] as '场次','' as '公司','非标准赔率' as  '类型'                                          
--,'低赔Oddset大于立博' as '说明','' as '距离比赛时间',0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',a.matchid,'' as companyid,a.termindex                                                         
--,null as '历史对阵'                                                                                     
-- from vcurrenteuropepan a inner join vcurrenteuropepan b                                       
--on a.termindex = b.termindex and a.matchid = b.matchid                                                         
--where a.companyid=370 and b.companyid=82                                                                                    
--and a.win < a.draw and a.draw < a.lose and b.win < b.draw and b.draw < b.lose                                                                                    
--and a.win > b.win             
--union all                                                                      
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                           
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                          
--,a.[MatchNumber] as '场次','' as '公司','非标准赔率' as  '类型'                            
--,'低赔Oddset大于立博' as '说明','' as '距离比赛时间',0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',a.matchid,'' as companyid,a.termindex                                            
--,null as '历史对阵'                                                                                     
-- from vcurrenteuropepan a inner join vcurrenteuropepan b                                           
--on a.termindex = b.termindex and a.matchid = b.matchid                                                                                    
--where a.companyid=370 and b.companyid=82                                                                                    
--and a.win > a.draw and a.draw > a.lose and b.win > b.draw and b.draw > b.lose                                                                                    
--and a.lose > b.lose;                                                                              
--union all                                                                              
select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
,a.[MatchNumber] as '场次',a.companyname as '公司','【超低水】' as  '类型'                                                                    
, cast(win as varchar(8))+ ' '+ pankou+ ' '+ cast(lose as varchar(8)) as '说明','' as '距离比赛时间',0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',                        
a.matchid,a.companyid as companyid,a.termindex                                     
,null as '历史对阵'                                                                                     
from  [vCurrentAsiaPan] a where win < 0.66 or lose < 0.66                                                                           
union all                                                                          
select 赛果,对阵                                                                                    
,比分,让球, 时间                                                                                   
,场次,公司,类型                                              
, '立博大于必发' as '说明',距离比赛时间,x1.win,x1.draw,x1.lose,OldMatchId,x1.matchid,companyid,termindex                                                                                    
,历史对阵          from (                                                                          
select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
,'' as '比分','' as '让球', a.[MatchTime] as '时间'              
,a.[MatchNumber] as '场次',a.companyname as '公司','【必发指数】' as  '类型'                                                                                    
,'' as '距离比赛时间',win,draw,lose,null as 'OldMatchId',a.matchid,a.companyid as companyid,a.termindex                                                      
,null as '历史对阵'                                                                                     
from  [vCurrenteuropePan] a                               
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                     
and v1.companyid = a.companyid                                                                          
and v1.companyid = 82 order by v1.createtime desc                                                                          
)                                                                          
) x1 inner join                                                                       
(                                                                          
select  win ,draw,lose,matchid                                                
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid               
and v1.companyid = a.companyid                                                                           
and v1.companyid = 2 order by v1.createtime desc                                                                          
)                         
) x2 on x1.matchid = x2.matchid and ((x1.win <2 and x1.win > x2.win and x1.win >1.19 ) or (x1.lose <2 and x1.lose > x2.lose and x1.lose >1.19  ))                                                                  
union all                                                               
select 赛果,对阵                                                                                    
,比分,让球, 时间                                                                                   
,场次,公司,类型                                       
, '威廉大于必发' as '说明',距离比赛时间,x1.win,x1.draw,x1.lose,OldMatchId,x1.matchid,companyid,termindex                                                                                    
,历史对阵          from (                                                                          
select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
,a.[MatchNumber] as '场次',a.companyname as '公司','【必发指数】' as  '类型'                                                                                    
,'' as '距离比赛时间',win,draw,lose,null as 'OldMatchId',a.matchid,a.companyid as companyid,a.termindex                                         
,null as '历史对阵'                                                                                     
from  [vCurrenteuropePan] a                                                      
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
and v1.companyid = a.companyid                                                                           
and v1.companyid = 115 order by v1.createtime desc                                                                          
)                                                                          
) x1 inner join                                                                           
(                                                                          
select  win ,draw,lose,matchid                                                                      
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
and v1.companyid = a.companyid                                                                           
and v1.companyid = 2 order by v1.createtime desc                                                                 
)                                                                          
) x2 on x1.matchid = x2.matchid and ((x1.win <2 and x1.win > x2.win and x1.win >1.19 ) or (x1.lose <2 and x1.lose > x2.lose and x1.lose >1.19  ))                                
union all --澳门大于威廉希尔                                                                          
select 赛果,对阵                                                                                    
,比分,让球, 时间                            
,场次,公司,类型                                                           
, '澳门大于威廉希尔' as '说明',距离比赛时间,x1.win,x1.draw,x1.lose,OldMatchId,x1.matchid,companyid,termindex                                                                                    
,历史对阵          from (                                                                          
select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                              
,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
,a.[MatchNumber] as '场次',a.companyname as '公司','【澳门大于威廉希尔】' as  '类型'                                                                    
,'' as '距离比赛时间',win,draw,lose,null as 'OldMatchId',a.matchid,a.companyid as companyid,a.termindex                                                                                    
,null as '历史对阵'                                                                                     
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                 
and v1.companyid = a.companyid                                                                           
and v1.companyid = 80 order by v1.createtime desc                                                                          
)                                                                          
) x1 inner join                                                                           
(                                                           
select  win ,draw,lose,matchid                                                                          
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
and v1.companyid = a.companyid                                         
and v1.companyid = 115 order by v1.createtime desc                                                                          
)                                                                          
) x2 on x1.matchid = x2.matchid and ((x1.win <2 and x1.win > x2.win and x1.win >1.20 ) or (x1.lose <2 and x1.lose > x2.lose and x1.lose >1.20  ))                                                                 
--union all        --keyplayer                                                                
--select null as 赛果,a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
--,a.[MatchNumber] as '场次','' as '公司', 'KeyPlayer' 类型,                                                                         
--b.description as '说明',                                                                        
--'' as 距离比赛时间,0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',a.matchid,null,termindex                                                                         
--, null as 历史对阵   from                                                                
-- currentmatch a inner join v_teamkeyplayer  b                                                                 
--on a.matchid = b.matchid                                                            
--union all                                                                
--select null as 赛果,[HomeTeam] +'-'+awayteam,'' as '比分',letball as '让球', [MatchTime] as '时间'                                                                          
--,[MatchNumber] as '场次',companyname as '公司', '【关键变化】' 类型,                                                                         
--companyname+'变化' as '说明',                                                                        
--'' as 距离比赛时间,0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',matchid,companyid,termindex                                                    
--, null as 历史对阵 from vCurrentEuropePan where companyid = 370 or companyid = 450                                                                
--group by matchid,companyid,[HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,termindex                                                                
--having count(1) > 1            
--union all                                                                
--select null as 赛果,[HomeTeam] +'-'+awayteam,'' as '比分',letball as '让球', [MatchTime] as '时间'                                         
--,[MatchNumber] as '场次',companyname as '公司', '【关键变化】' 类型,                                                                         
--companyname+'变化' as '说明',                                                          
--'' as 距离比赛时间,0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',matchid,null,termindex                                                                                    
--, null as 历史对阵 from vCurrentEuropePan where companyid = 115 and leaguename='葡甲'                                             
--group by matchid,companyid,[HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,termindex                                                                
--having count(1) > 1                                                              
union all                         
select                        
null as 赛果,f.[HomeTeam] +'-'+f.awayteam,'' as '比分',f.letball as '让球', f.[MatchTime] as '时间'                                                                          
,f.[MatchNumber] as '场次',f.companyname as '公司', '【关键变化】' 类型,                                                                         
 cast(f.win as varchar(10))+ ' '+cast(f.draw as varchar(10))+' ' +cast(f.lose as varchar(10))                         
+ '\r\n'+ cast(l.win as varchar(10))+ ' '+cast(l.draw as varchar(10))+' ' +cast(l.lose as varchar(10)) as '说明',                                                                        
'' as 距离比赛时间,0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',f.matchid,f.companyid,f.termindex                                                                                   
, null as 历史对阵                        
  from                         
(                        
select  win ,draw,lose,matchid,a.companyid,a.matchnumber,[HomeTeam],awayteam,letball,[MatchTime],termindex,companyname                        
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
and v1.companyid = a.companyid                                         
and v1.companyid in (370,450) order by v1.createtime )                        
) f                        
inner join                         
(                        
select  win ,draw,lose,matchid,a.companyid,a.matchnumber,[HomeTeam],awayteam,letball,[MatchTime],termindex,companyname                        
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
and v1.companyid = a.companyid                                         
and v1.companyid in (370,450) order by v1.createtime desc     )                        
)l                        
on f.matchid = l.matchid and f.companyid = l.companyid  and (f.win <> l.win or f.draw <> l.draw or f.lose <> l.lose)                                               
union all --平赔高开                                                                
select null as 赛果,[HomeTeam] +'-'+awayteam,'' as '比分',letball as '让球', [MatchTime] as '时间'                                                     
,[MatchNumber] as '场次',a.companyname as '公司', '【平赔高开】' 类型,                                                                         
a.companyname+ ' ' + cast(maxdraw as varchar(10))  as '说明',                                                                        
'' as 距离比赛时间,b.win,b.draw,b.lose,null as 'OldMatchId',matchid,a.companyid,termindex                                                                                    
, null as 历史对阵 from dbo.CompanyMaxDraw                                                                
a inner join vCurrentEuropePan b                                                                 
on a.companyid = b.companyid                                                                
where b.draw > b.lose and b.draw > b.win and b.draw >= a.[maxdraw]           
--union all                                                           
--select null as 赛果,[HomeTeam] +'-'+awayteam,'' as '比分',letball as '让球', [MatchTime] as '时间'                                                                                    
--,[MatchNumber] as '场次',b.companyname as '公司', '【返还率警戒线-MAX】' 类型,                     
--'最大:'+cast(a.begin_maxreturn as varchar(10))+' 本场:'+ cast(b.returnrate as varchar(10))  as '说明',                                                                        
--'' as 距离比赛时间,b.win,b.draw,b.lose,null as 'OldMatchId',matchid,a.companyid,termindex                                     
--, null as 历史对阵 from dbo.ReturnRate a inner join vCurrentEuropePan b                                     
--on a.companyid = b.companyid and a.leaguename = b.leaguename                                                                 
--where b.pantype='初盘' and b.returnrate+0.06 >= a.begin_maxreturn and a.companyid    in (0,115,82,80,104,281)                                                         
--union all --返还率警戒线 接近最小值                                                                
--select null as 赛果,[HomeTeam] +'-'+awayteam,'' as '比分',letball as '让球', [MatchTime] as '时间'                                                                                    
--,[MatchNumber] as '场次',b.companyname as '公司', '【返还率警戒线-min】' 类型,                                                                         
--'最小:'+cast(a.begin_minreturn as varchar(10))+' 本场:'+ cast(b.returnrate as varchar(10))  as '说明',                                                                            
--'' as 距离比赛时间,b.win,b.draw,b.lose,null as 'OldMatchId',matchid,a.companyid,termindex                                                                                    
--, null as 历史对阵 from dbo.ReturnRate a inner join vCurrentEuropePan b                                                                 
--on a.companyid = b.companyid and a.leaguename = b.leaguename                                                                 
--where b.pantype='初盘' and b.returnrate-0.06 <= a.begin_minreturn and a.companyid   in (0,115,82,80,104,281)                                                             
--select null as 赛果,[HomeTeam] +'-'+awayteam,'' as '比分',letball as '让球', [MatchTime] as '时间'                                                                                    
--,[MatchNumber] as '场次',b.companyname as '公司', '【返还率警戒线-MAX】' 类型,                     
--'最大:'+cast(a.begin_maxreturn as varchar(10))+' 本场:'+ cast(b.returnrate as varchar(10))  as '说明',                                                                        
--'' as 距离比赛时间,b.win,b.draw,b.lose,null as 'OldMatchId',matchid,a.companyid,termindex                                     
--, null as 历史对阵 from dbo.ReturnRate a inner join vCurrentEuropePan b                                     
--on a.companyid = b.companyid and a.leaguename = b.leaguename                                                                 
--where b.pantype='初盘' and b.returnrate >= a.begin_maxreturn and a.companyid not in (2,158, 432, 450, 474,370)                                                                
--union all --返还率警戒线 接近最小值                                                                
--select null as 赛果,[HomeTeam] +'-'+awayteam,'' as '比分',letball as '让球', [MatchTime] as '时间'                                                                                    
--,[MatchNumber] as '场次',b.companyname as '公司', '【返还率警戒线-min】' 类型,                                                                         
--'最小:'+cast(a.begin_minreturn as varchar(10))+' 本场:'+ cast(b.returnrate as varchar(10))  as '说明',                                                                            
--'' as 距离比赛时间,b.win,b.draw,b.lose,null as 'OldMatchId',matchid,a.companyid,termindex                                                                                    
--, null as 历史对阵 from dbo.ReturnRate a inner join vCurrentEuropePan b                                                                 
--on a.companyid = b.companyid and a.leaguename = b.leaguename                                                                 
--where b.pantype='初盘' and b.returnrate <= a.begin_minreturn and a.companyid not in (2,158, 432, 450, 474,370)                                                
union all --初始差异                                                                
select  null as 赛果,a.[HomeTeam] +'-'+a.awayteam,'' as '比分',a.letball as '让球', a.[MatchTime] as '时间'                                                                                
,a.[MatchNumber] as '场次',b.companyname as '公司', '【初始差异】' 类型,                                                                         
'初：'+ CAST(a.win as varchar(10)) + ' ' + CAST(a.draw as varchar(10)) + ' '+CAST(a.lose as varchar(10)) + '\r\n'                                      
+'终：'+ CAST(b.win as varchar(10)) + ' ' + CAST(b.draw as varchar(10)) + ' '+CAST(b.lose as varchar(10))  as '说明',                                                                            
'' as 距离比赛时间,null,null,null,null as 'OldMatchId',a.matchid,a.companyid,a.termindex                                                                                    
, null as 历史对阵 from (                                                                
select  [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex,win,draw,lose from vcurrentEuropePan where pantype ='初盘' and companyid <>2                                                                
) a inner join (                                                                
select [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex,win,draw,lose from (                                                                
select   ROW_NUMBER() over(partition by matchid,companyid  order by createtime desc) as num,* from vcurrentEuropePan                                                                 
) a where a.num = 1 and a.companyid <>2                                                                
) b                                                                
on a.termindex = b.termindex and a.matchid = b.matchid and a.companyid = b.companyid                               
where ((abs(a.win -b.win) > 0.45 and a.win >a.draw and a.draw > a.lose)  or (abs(a.lose -b.lose) > 0.45 and a.lose <a.draw and a.draw < a.win) )                               
or ((a.win < 1.2 and b.win>=1.3) or (a.lose < 1.2 and b.lose>=1.3))                                                       
 --union all --SNAI                                                                        
--select null as 赛果,a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                               
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
--,a.[MatchNumber] as '场次',a.companyname as '公司', 'SNAI' 类型,                                                                         
--case when win_upordown = 1 and draw_upordown = -1 and lose_upordown =0 then '主升，平降，客不动，则常平'                                                                       
--when win_upordown = 0 and draw_upordown = -1 and lose_upordown =1 then '主不动，平降，客升，则无平'                            
--when win_upordown <> 0 and draw_upordown = 0 and lose_upordown <>0 then '主动，平不动，客动，则无平'                                                                         
--when win_upordown =1 and draw_upordown = -1 and lose_upordown <>0 then '主升，平降，客动，则无主胜' else 'NULL' end                                                                        
-- as '说明',                                                                        
--'' as 距离比赛时间,0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',matchid,110,termindex                                                                                    
--, null as 历史对阵   from  vCurrentEuropepan a  where panid =                                                                        
--( select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid and v1.companyid=110 order by v1.createtime desc  )                        
--and companyid = 110                                                                         
--union all --澳门大于立博                                                                          
--select 赛果,对阵                                     
--,比分,让球, 时间                                                                                   
--,场次,公司,类型                                                                  
--, '澳门大于立博' as '说明',距离比赛时间,x1.win,x1.draw,x1.lose,OldMatchId,x1.matchid,companyid,termindex                                           
--,历史对阵          from (                                              
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
--,a.[MatchNumber] as '场次',a.companyname as '公司','澳门大于立博' as  '类型'                                                                                    
--,'' as '距离比赛时间',win,draw,lose,null as 'OldMatchId',a.matchid,a.companyid as companyid,a.termindex                                                                                    
--,null as '历史对阵'                                                                  
--from  [vCurrenteuropePan] a                                                                          
--where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
--and v1.companyid = a.companyid                                                                           
--and v1.companyid = 80 order by v1.createtime desc                                                                          
--)                                           
--) x1 inner join                                                                           
--(           
--select  win ,draw,lose,matchid                                                                          
--from  [vCurrenteuropePan] a                                                                          
--where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
--and v1.companyid = a.companyid                                                                           
--and v1.companyid = 82 order by v1.createtime desc                                                                          
--)                                              
--) x2 on x1.matchid = x2.matchid and ((x1.win <2 and x1.win > x2.win and x1.win >1.20 ) or (x1.lose <2 and x1.lose > x2.lose and x1.lose >1.20  ))                                                                
--union all --TOTO大于威廉希尔                                                                          
--select 赛果,对阵                                                                                    
--,比分,让球, 时间                                                                                   
--,场次,公司,类型                                                                                
--, 'TOTO大于威廉希尔' as '说明',距离比赛时间,x1.win,x1.draw,x1.lose,OldMatchId,x1.matchid,companyid,termindex                                                                                    
--,历史对阵          from (                                                                          
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
--,a.[MatchNumber] as '场次',a.companyname as '公司','TOTO大于威廉希尔' as  '类型'                            
--,'' as '距离比赛时间',win,draw,lose,null as 'OldMatchId',a.matchid,a.companyid as companyid,a.termindex                                                                                    
--,null as '历史对阵'                                                                                     
--from  [vCurrenteuropePan] a                                                                          
--where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
--and v1.companyid = a.companyid                                                                   
--and v1.companyid = 450 order by v1.createtime desc                                                                          
--)                                                            
--) x1 inner join                                             
--(                                                                          
--select  win ,draw,lose,matchid                                                                          
--from  [vCurrenteuropePan] a                                                                          
--where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
--and v1.companyid = a.companyid                                                                           
--and v1.companyid = 115 order by v1.createtime desc                                                                          
--)                                                                          
--) x2 on x1.matchid = x2.matchid and ((x1.win <2 and x1.win > x2.win and x1.win >1.20 ) or (x1.lose <2 and x1.lose > x2.lose and x1.lose >1.20  ))                                                                  
--union all --TOTO大于立博                                                                         
--select 赛果,对阵                                                                                    
--,比分,让球, 时间                                                                                   
--,场次,公司,类型                                                                                
--, 'TOTO大于立博' as '说明',距离比赛时间,x1.win,x1.draw,x1.lose,OldMatchId,x1.matchid,companyid,termindex                                                       
--,历史对阵          from (                                                                          
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                            
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                  
--,a.[MatchNumber] as '场次',a.companyname as '公司','TOTO大于立博' as  '类型'                                                                            
--,'' as '距离比赛时间',win,draw,lose,null as 'OldMatchId',a.matchid,a.companyid as companyid,a.termindex                                                                                    
--,null as '历史对阵'                                                                                     
--from  [vCurrenteuropePan] a                                         
--where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
--and v1.companyid = a.companyid                                                                           
--and v1.companyid = 450 order by v1.createtime desc                                                                          
--)                                                                          
--) x1 inner join                                                             
--(                                                 
--select  win ,draw,lose,matchid                                                                  
--from  [vCurrenteuropePan] a                                                  
--where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                        
--and v1.companyid = a.companyid                                                                           
--and v1.companyid = 82 order by v1.createtime desc                                                                          
--)                                            
--) x2 on x1.matchid = x2.matchid and ((x1.win <2 and x1.win > x2.win and x1.win >1.20 ) or (x1.lose <2 and x1.lose > x2.lose and x1.lose >1.20  ))                                                             
union                                                            
select distinct null as 赛果,b.[HomeTeam] +'-'+b.awayteam,'' as '比分',b.letball as '让球', b.[MatchTime] as '时间'                                                                                    
,b.[MatchNumber] as '场次',null as '公司', '一周双赛' 类型,                                                                         
a.HomeTeam  as '说明',                               
'' as 距离比赛时间,b.win,b.draw,b.lose,null as 'OldMatchId',b.matchid,null,b.termindex                                                                                    
, null as 历史对阵 from historymatch a                                                            
inner join currentmatch b                                                            
on a.HomeTeam = b.HomeTeam or a.HomeTeam = b.AwayTeam                                                         
where DATEDIFF(DAY,a.MatchTime,GETDATE()) < 3 and b.TermIndex not in (select top 1 TermIndex from CurrentMatch  )                                                          
  union all                        
select distinct null as 赛果,b.[HomeTeam] +'-'+b.awayteam,'' as '比分',b.letball as '让球', b.[MatchTime] as '时间'                                                                                    
,b.[MatchNumber] as '场次',null as '公司', '一周双赛' 类型,                                                                         
b.AwayTeam  as '说明',                                               
'' as 距离比赛时间,b.win,b.draw,b.lose,null as 'OldMatchId',b.matchid,null,b.termindex                                                                                    
, null as 历史对阵 from historymatch a                                                            
inner join currentmatch b                                                            
on a.AwayTeam = b.HomeTeam or a.AwayTeam = b.AwayTeam                                                              
where DATEDIFF(DAY,a.MatchTime,GETDATE()) < 3 and b.TermIndex not in (select top 1 TermIndex from CurrentMatch  )                                                           
--union all              
--select 赛果,对阵             
--,比分,让球, 时间                                                          
--,场次,公司,类型                                                                                
--, 'Oddset大于威廉希尔' as '说明',距离比赛时间,x1.win,x1.draw,x1.lose,OldMatchId,x1.matchid,companyid,termindex                                                                                    
--,历史对阵          from (                                                                          
--select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
--,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                           
--,a.[MatchNumber] as '场次',a.companyname as '公司','【Oddset大于威廉希尔】' as  '类型'                                                         
--,'' as '距离比赛时间',win,draw,lose,null as 'OldMatchId',a.matchid,a.companyid as companyid,a.termindex                                                                                    
--,null as '历史对阵'                                                                                     
--from  [vCurrenteuropePan] a                                                                          
--where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
--and v1.companyid = a.companyid                                                  
--and v1.companyid = 370 order by v1.createtime desc  )                                                          
--) x1 inner join                                                                           
--(                                                                          
--select  win ,draw,lose,matchid                                                                          
--from  [vCurrenteuropePan] a                                                                     
--where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
--and v1.companyid = a.companyid                                                                           
--and v1.companyid = 115 order by v1.createtime desc                                                                          
--)                                                             
--) x2 on x1.matchid = x2.matchid and ((x1.win > x2.win ) or ( x1.lose > x2.lose   ) or (x1.draw > x2.draw))                                                            
--union all                                                    
--select 赛果,对阵,比分,让球,时间,场次,公司,类型,说明,距离比赛时间,win,draw,lose,oldmatchid,matchid,companyid,TermIndex,历史对阵 from (                                                   
--select distinct null as '赛果',b.[HomeTeam] +'-'+b.awayteam as '对阵'                                                                                    
--,'' as '比分','' as '让球', b.[MatchTime] as '时间'                                                                                    
--,b.[MatchNumber] as '场次',null as '公司','上次交锋' as  '类型'                                                                                 
--, a.[HomeTeam] +'-'+a.awayteam +'('+ a.Score +') '+ c.PanKou  as '说明','' as '距离比赛时间',0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',b.matchid,                                                    
--null as companyid,b.termindex             
--,null as '历史对阵', ROW_NUMBER() over (PARTITION BY b.[HomeTeam] +'-'+b.awayteam ORDER BY a.matchtime desc  ) as num                                                                      
--from  HistoryMatch a inner join  CurrentMatch b                                                     
--on (a.HomeTeam = b.HomeTeam and a.AwayTeam = b.AwayTeam) or (a.HomeTeam = b.AwayTeam and a.AwayTeam = b.HomeTeam)                                                    
--inner join HistoryAsiaPan c on a.MatchID = c.MatchID                                                    
--where c.PanType ='初盘'                                            
--) d                           
--where num = 1                                                    
--union all                                                  
--select distinct   null as '赛果',b.[HomeTeam] +'-'+b.awayteam as '对阵'                                                                                    
--,'' as '比分','' as '让球', b.[MatchTime] as '时间'                                                   
--,b.[MatchNumber] as '场次',null as '公司','【盘口匹配】' as  '类型'                                                                                    
--, a.Remark + ' ' + a.DaxiaoQiu  as '说明','' as '距离比赛时间',0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',b.matchid,                                                    
--null as companyid,b.termindex                              
--,null as '历史对阵'                                                                 
--from  YaPan_DaXiaoQiu a inner join  CurrentMatch b                                                     
--on  a.MatchID = b.MatchID                                                    
--where isnull(a.Remark,'') != '' and not exists                                                   
--(select 1 from Forecast f where f.Type ='【盘口匹配】' and f.TermIndex = a.TermIndex and f.MatchID = a.MatchId)                                                  
--union all --必发异常                                                
--select distinct   null as '赛果',b.[HomeTeam] +'-'+b.awayteam as '对阵'                   
--,'' as '比分',a.letball as '让球', b.[MatchTime] as '时间'                                                         
--,b.[MatchNumber] as '场次',null as '公司','【必发异常】' as  '类型'                                                                                    
--, replace(replace (CAST( a.companyid AS VARCHAR(10)),'115','威廉希尔'),'82','立博') + '：'+ cast( a.win as  varchar(10)) +' ' +  cast( a.draw as varchar(10)) + ' ' + cast( a.lose as varchar(10))                                               
--+ '\r\n' + '必发：' + cast( b.win as  varchar(10)) +' ' +  cast( b.draw as varchar(10)) + ' ' + cast( b.lose as varchar(10))  as '说明',                                              
--'' as '距离比赛时间',0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId',b.matchid,                           
--null as companyid,b.termindex,null as '历史对阵'                                                  
--from  vCurrentEuropePan a inner join  vCurrentEuropePan b                                                
--on  a.MatchID = b.MatchID                                                 
--where ((a.win < a.draw and a.draw < a.lose and b.win < b.draw and b.win < b.lose and b.lose < b.draw and a.win <=1.90)                                                
--or     a.win > a.draw and a.draw > a.lose and b.lose < b.win and b.lose < b.draw and b.win <b.draw and a.lose <= 1.90                                   
--or                                                
--a.win < a.draw and a.draw < a.lose and b.win < b.draw and b.draw < b.lose and b.lose <=a.lose                                                
--or                            
--a.win > a.draw and a.draw>a.lose and b.win > b.draw and b.draw > b.lose and b.win <=a.win                                      
--)                                                
--and a.companyid in (82,115) and b.companyid =2                                                
--and (a.panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
--and v1.companyid = a.companyid                                                                           
--and v1.companyid =82 order by v1.createtime desc                                                                          
--)     or                                               
--a.panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
--and v1.companyid = a.companyid                               
--and v1.companyid =115 order by v1.createtime desc                                                                          
--)                                               
--)                  
--and b.panid =  (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = b.matchid                                                                           
--and v1.companyid = b.companyid                                                                           
--and v1.companyid = 2 order by v1.createtime desc                                                                          
--)                                                                      
-- and not exists                                                   
--(select 1 from Forecast f where f.Type ='【必发异常】' and f.TermIndex = a.TermIndex and f.MatchID = a.MatchId   )                                      
union all --                                        
select null as '赛果', a.[HomeTeam] +'-'+ a.awayteam as '对阵'                                    
,'' as '比分', a.letball as '让球', a.[MatchTime] as '时间'                                                         
, a.[MatchNumber] as '场次',null as '公司','【威廉立博组合】' as  '类型'                                                                                    
, '威廉：' +                                        
cast( b.win as  varchar(10)) +' ' +  cast( b.draw as varchar(10)) + ' ' + cast( b.lose as varchar(10))                                               
+ '\r\n' + '立博：' + cast( a.win as  varchar(10)) +' ' +  cast( a.draw as varchar(10)) + ' ' + cast( a.lose as varchar(10))                                         
 as '说明',                                              
'' as '距离比赛时间',0 as 'win',0 as 'draw',0 as 'lose',null as 'OldMatchId', a.matchid,                                 
null as companyid, a.termindex,null as '历史对阵'                                                  
 from (                                        
select matchid,companyid,LetBall,win,draw,lose,termindex,HomeTeam,awayteam,[MatchNumber],[MatchTime] from (                                        
select matchid,companyid,LetBall,win,draw,lose ,termindex,HomeTeam,awayteam,[MatchNumber],[MatchTime],                                        
ROW_NUMBER() OVER(PARTITION BY matchid ORDER BY createtime desc) as row                                        
from vCurrentEuropePan where companyid =82                                        
) m                                        
where m.row = 1                                        
) a                                        
inner join                                        
(                                        
select matchid,companyid,LetBall,win,draw,lose,termindex,HomeTeam,awayteam,[MatchNumber],[MatchTime] from (                                        
select matchid,companyid,LetBall,win,draw,lose ,termindex,HomeTeam,awayteam,[MatchNumber],[MatchTime],                                        
ROW_NUMBER() OVER(PARTITION BY matchid ORDER BY createtime desc) as row                                        
from vCurrentEuropePan where companyid =115                     
) m                                        
where m.row = 1                              
) b                                        
on a.matchid = b.matchid                                        
where                                          
(a.win < a.draw and a.draw <= a.lose and a.win < a.lose and  b.win < b.draw and b.draw <= b.lose and b.win < b.lose and a.win < b.win and a.draw >= b.draw and a.lose >= b.lose)                                        
or                                        
(a.win >= a.draw and a.draw > a.lose and a.win > a.lose and  b.win >= b.draw and b.draw > b.lose and b.win > b.lose and a.lose < b.lose and a.draw >= b.draw and a.win >= b.win)                                      
union all -- 赔率倒置                                      
select  null as 赛果,a.[HomeTeam] +'-'+a.awayteam,'' as '比分',a.letball as '让球', a.[MatchTime] as '时间'                    
,a.[MatchNumber] as '场次',b.companyname as '公司', '【赔率倒置】' 类型,                                                                         
'初：'+ CAST(a.win as varchar(10)) + ' ' + CAST(a.draw as varchar(10)) + ' '+CAST(a.lose as varchar(10)) + '\r\n'                                      
+'终：'+ CAST(b.win as varchar(10)) + ' ' + CAST(b.draw as varchar(10)) + ' '+CAST(b.lose as varchar(10))  as '说明',                           
'' as 距离比赛时间,null,null,null,null as 'OldMatchId',a.matchid,a.companyid,a.termindex                          
, null as 历史对阵 from (                                                                
select  [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex,win,draw,lose from vcurrentEuropePan where pantype ='初盘' and companyid <>2                                                                
) a inner join (                                                                
select [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex,win,draw,lose from (                                                                
select   ROW_NUMBER() over(partition by matchid,companyid  order by createtime desc) as num,* from vcurrentEuropePan                                          
) a where a.num = 1 and a.companyid <>2                                                                
) b                                                                
on a.termindex = b.termindex and a.matchid = b.matchid and a.companyid = b.companyid                                                                
where (a.win < a.draw and a.draw > a.lose and a.win < a.lose and b.win > b.draw and b.draw > b.lose and b.win > b.lose)--132->231                                      
or (a.win < a.draw and a.draw > a.lose and a.win > a.lose and b.win < b.lose and b.draw > b.lose and b.win < b.lose) --231->132                                      
or (a.win < a.draw and a.win < a.lose and a.draw < a.lose and b.win < b.draw and b.win < b.lose and b.draw > b.lose)--123->132                                      
or (a.win < a.draw and a.win < a.lose and a.draw > a.lose and b.win > b.draw and b.win > b.lose and b.draw < b.lose)--132->123                                      
or (a.win > a.draw and a.draw > a.lose and b.lose < b.win and b.lose < b.draw and b.draw > b.win)--321->231                                      
or (a.lose < a.win and a.lose < a.win and a.draw > a.win and b.lose < b.draw and b.draw < b.win)--231->321                                      
or (a.win < a.draw and a.draw < a.lose and b.lose < b.draw and b.draw < b.win)--123->321                                      
or (a.lose < a.draw and a.draw < a.win and b.win < b.draw and b.draw < b.lose)--321->123                                      
or (a.win < a.draw and a.draw < a.lose and b.lose < b.win and b.lose < b.draw and b.win < b.draw)--123->231                                      
or (a.lose < a.win and a.lose < a.draw and a.win < a.draw and b.win < b.draw and b.draw < b.lose)--231->123                                      
union all   --最近升降 欧                                    
select  null as 赛果, [HomeTeam] +'-'+ awayteam,'' as '比分', letball as '让球',  [MatchTime] as '时间'                                                                                
, [MatchNumber] as '场次', companyname as '公司', '连续升降（欧）' 类型,                           
说明,                                                                            
'' as 距离比赛时间,null,null,null,null as 'OldMatchId', matchid, companyid, termindex                                                                                    
, null as 历史对阵 from (                                         
select  [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex,sum(win_upordown) as wincount,sum(draw_upordown) as drawcount,sum(lose_upordown) as losecount,                                      
case when sum(win_upordown) = 5 then '主胜升' when sum(win_upordown) =  -5 then '主胜降'                      
when sum(draw_upordown) = 5 then '平升' when sum(draw_upordown) =  -5 then '平降'                                      
when sum(lose_upordown) = 5 then '客胜升' when sum(lose_upordown) =  -5 then '客胜降' end 说明                                      
 from (                                      
select  [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex,win,draw,lose,win_upordown,draw_upordown,lose_upordown,                                      
ROW_NUMBER() over(partition by matchid,companyid  order by createtime desc) as num                               from vcurrentEuropePan                                      
 ) a                                      
 where a.num <=5                                      
 group by [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex                                      
having abs(sum(win_upordown)) = 5 or  abs(sum(draw_upordown)) = 5 or abs(sum(lose_upordown)) = 5                      
) b                                      
  union all   --最近升降 亚                                    
select  null as 赛果, [HomeTeam] +'-'+ awayteam,'' as '比分', letball as '让球',  [MatchTime] as '时间'                                                                                
, [MatchNumber] as '场次', companyname as '公司', '连续升降（亚）' 类型,                                                                         
说明,                                            
'' as 距离比赛时间,null,null,null,null as 'OldMatchId', matchid, companyid, termindex                                                           
, null as 历史对阵 from (                                         
select  [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex,sum(win_upordown) as wincount, sum(lose_upordown) as losecount,                                      
case when sum(win_upordown) = 5 then '主胜升' when sum(win_upordown) =  -5 then '主胜降'                                      
when sum(lose_upordown) = 5 then '客胜升' when sum(lose_upordown) =  -5 then '客胜降' end 说明                                      
 from (                                      
select  [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex,win,lose,win_upordown,lose_upordown,                                      
ROW_NUMBER() over(partition by matchid,companyid  order by createtime desc) as num                                      
 from vCurrentAsiaPan               
 ) a                                      
 where a.num <=5                                      
 group by [HomeTeam],awayteam,letball,[MatchTime],[MatchNumber],companyname,matchid,companyid,termindex                                      
having abs(sum(win_upordown)) = 5 or   abs(sum(lose_upordown)) = 5                                      
) b                         
--union all  --密集赛程                      
--select  null as 赛果, a.[HomeTeam] +'-'+ a.awayteam,'' as '比分', a.letball as '让球',  a.[MatchTime] as '时间'                         
--, a.[MatchNumber] as '场次', null as '公司', '密集赛程' 类型, a.[HomeTeam]  说明,                         
--'' as 距离比赛时间,null,null,null,null as 'OldMatchId', a.matchid, null, a.termindex , null as 历史对阵                         
--from CurrentMatch a inner join HistoryMatch b                        
--on (a.HomeTeam = b.HomeTeam or a.HomeTeam = b.AwayTeam)                         
--where DATEDIFF(DD,b.MatchTime,a.MatchTime) < 14  and not exists(select 1 from Forecast b where b.TermIndex = a.TermIndex and b.MatchID = a.MatchID and b.Type= '密集赛程' )                        
--group by a.HomeTeam,a.AwayTeam ,a.letball,a.MatchID,a.[MatchTime],a.[MatchNumber],a.termindex                        
--having COUNT(a.HomeTeam) > 3                        
--union all                        
--select  null as 赛果, a.[HomeTeam] +'-'+ a.awayteam,'' as '比分', a.letball as '让球',  a.[MatchTime] as '时间'                         
--, a.[MatchNumber] as '场次', null as '公司', '密集赛程' 类型, a.AwayTeam  说明,                         
--'' as 距离比赛时间,null,null,null,null as 'OldMatchId', a.matchid, null, a.termindex , null as 历史对阵                         
--from CurrentMatch a inner join HistoryMatch b                        
--on  ( a.AwayTeam = b.HomeTeam or a.AwayTeam = b.AwayTeam)                         
--where DATEDIFF(DD,b.MatchTime,a.MatchTime) < 14  and not exists(select 1 from Forecast b where b.TermIndex = a.TermIndex and b.MatchID = a.MatchID and b.Type= '密集赛程' )                        
--group by a.HomeTeam,a.AwayTeam ,a.letball,a.MatchID,a.[MatchTime],a.[MatchNumber],a.termindex                        
--having COUNT(a.AwayTeam) > 3                     
union all                  
select 赛果,对阵                                              
,比分,让球, 时间                                                                                   
,场次,公司,类型                                              
, '竞猜大于威廉\r\n竞猜:'+ cast(x1.win as varchar(8)) + ' ' + cast(x1.draw as varchar(8))+ ' '  + cast(x1.lose as varchar(8))                   
+ '\r\n威廉:' + cast(x2.win as varchar(8))+ ' '  + cast(x2.draw as varchar(8))+ ' '  + cast(x2.lose as varchar(8))                   
as '说明',距离比赛时间,x1.win,x1.draw,x1.lose,OldMatchId,x1.matchid,companyid,termindex                                                                                    
,历史对阵          from (                                                                          
select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
,a.[MatchNumber] as '场次',a.companyname as '公司','【竞猜指数】' as  '类型'                                                                                    
,'' as '距离比赛时间',win,draw,lose,null as 'OldMatchId',a.matchid,a.companyid as companyid,a.termindex                      
,null as '历史对阵'                                                                                     
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                     
and v1.companyid = a.companyid                                                                           
and v1.companyid = 0 order by v1.createtime desc                                                                          
)                                                                          
) x1 inner join                                                                           
(                                                                          
select  win ,draw,lose,matchid                                                
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
and v1.companyid = a.companyid                                                                           
and v1.companyid = 115 order by v1.createtime desc                                                                          
)                                                                          
) x2 on x1.matchid = x2.matchid                    
where x1.win >x2.win or x1.draw > x2.draw or x1.lose > x2.lose                
union all                  
select 赛果,对阵                                              
,比分,让球, 时间                                                                                   
,场次,公司,类型                                              
, '竞猜大于必发\r\n竞猜:'+ cast(x1.win as varchar(8)) + ' ' + cast(x1.draw as varchar(8))+ ' '  + cast(x1.lose as varchar(8))                   
+ '\r\n威廉:' + cast(x2.win as varchar(8))+ ' '  + cast(x2.draw as varchar(8))+ ' '  + cast(x2.lose as varchar(8))                   
as '说明',距离比赛时间,x1.win,x1.draw,x1.lose,OldMatchId,x1.matchid,companyid,termindex                                        
,历史对阵          from (                                                                          
select distinct null as '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵'                                                                                    
,'' as '比分','' as '让球', a.[MatchTime] as '时间'                                                                                    
,a.[MatchNumber] as '场次',a.companyname as '公司','【竞猜指数】' as  '类型'                                                                                    
,'' as '距离比赛时间',win,draw,lose,null as 'OldMatchId',a.matchid,a.companyid as companyid,a.termindex                                                      
,null as '历史对阵'                                                                                     
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                     
and v1.companyid = a.companyid                                                                  
and v1.companyid = 0 order by v1.createtime desc                                                                          
)                                                                          
) x1 inner join                                                                           
(                                                                          
select  win ,draw,lose,matchid                                                
from  [vCurrenteuropePan] a                                                                          
where panid = (select top 1 panid from [vCurrenteuropePan] v1 where v1.matchid = a.matchid                                                                           
and v1.companyid = a.companyid                                                                           
and v1.companyid = 2 order by v1.createtime desc                                                                          
)                                                                          
) x2 on x1.matchid = x2.matchid                    
where x1.win >x2.win or x1.draw > x2.draw or x1.lose > x2.lose        
union all        
select distinct null '赛果',a.[HomeTeam] +'-'+a.awayteam as '对阵',                       
null as '比分',a.letball as '让球', a.matchtime as '时间',                      
a.[MatchNumber] as '场次',a.companyname as '公司','【盘口异常】' as  '类型',                     
'让球：' + cast(a.LetBall as varchar(3)) + ' 盘口： ' + pankou as '说明',null as '距离比赛时间',null as 'win',null as 'draw',        
null as 'lose',null as 'OldMatchId',a.matchid,a.companyid,a.termindex,                                                                                    
null  as '历史对阵'                            
from vCurrentAsiaPan a        where (LetBall <0 and (pankou like '%受%' or pankou = '平手')) or (LetBall >0 and (pankou not like '%受%' or pankou = '平手'))        
or (LetBall =0 and (pankou  like '受一球%' or pankou  like '一球%'))     
union all     
select distinct null '赛果',c.[HomeTeam] +'-'+c.awayteam as '对阵',  
null as '比分',c.letball as '让球', c.matchtime as '时间',                      
c.[MatchNumber] as '场次',null as '公司','【'+ b.tag+'】' as  '类型',  
 a.说明, null as '距离比赛时间',null as 'win',null as 'draw',        
null as 'lose',null as 'OldMatchId',c.matchid,null as companyid,c.termindex ,null  as '历史对阵'                                                        
from vInformation a inner join keyword b  
on a.说明 like '%'+b.Tag+'%'  
inner join CurrentMatch c on a.场次 = c.MatchNumber

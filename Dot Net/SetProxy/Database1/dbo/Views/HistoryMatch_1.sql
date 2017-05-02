create view HistoryMatch_1
as
select   case when a + letball > b  then win when a + letball < b then lose else draw end as ActualEuro,

* from (
select  CAST( substring(score,0,CHARINDEX(':',score)) as int) a, CAST( substring(score,CHARINDEX(':',score)+1,LEN(score)) as int) b, MatchSP*0.65 ActualMatchSP, 
* from HistoryMatch 
where   Win >1 and Lose > 1 and Draw > 1 and Score <>'*' and Result != -1
) c



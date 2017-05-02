CREATE view [dbo].vInformation as      

select   matchid,MatchTime,remark, ROW_NUMBER() OVER(PARTITION BY matchid ORDER BY 说明) AS ID, 说明,'aInf' as flag,场次, '球队信息' as username  from vForecast where 类型='球队信息' and TermIndex = (select distinct TermIndex from CurrentMatch)    

union all

select   match_id,null,null AS REMARK,ID,  content, 'bNote' as flag,matchnumber, [user_name] as username from NotesOkooo where IsDeleted is null and TermIndex = (select distinct TermIndex from CurrentMatch) 


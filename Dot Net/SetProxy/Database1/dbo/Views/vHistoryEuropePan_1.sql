
CREATE VIEW vHistoryEuropePan_1 AS   
select   matchid,termindex,win,draw,lose,returnrate,score,result,pantype, companyid,letball,
ROW_NUMBER()over(PARTITION  BY matchid,companyid order by createtime  ) as RowNumber,
(select COUNT(1) from HistoryPan a  where  a.matchid = v.matchid and a.CompanyID = v.companyid ) as RowTotal
 from vHistoryEuropePan  v
 CREATE VIEW vCurrentEuropePan_1 AS   
select   matchid,termindex,win,draw,lose,returnrate,pantype, companyid,letball,
ROW_NUMBER()over(PARTITION  BY matchid,companyid order by createtime  ) as RowNumber,
(select COUNT(1) from CurrentPan a  where  a.matchid = v.matchid and a.CompanyID = v.companyid ) as RowTotal
 from vCurrentEuropePan  v

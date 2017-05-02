 create VIEW vCurrentAsiaPan_1 AS   
select   matchid,termindex,win,lose,pankou,pantype, companyid,letball,
ROW_NUMBER()over(PARTITION  BY matchid,companyid order by createtime  ) as RowNumber,
(select COUNT(1) from CurrentAsiaPan a  where  a.matchid = v.matchid and a.CompanyID = v.companyid ) as RowTotal
 from vCurrentAsiaPan  v

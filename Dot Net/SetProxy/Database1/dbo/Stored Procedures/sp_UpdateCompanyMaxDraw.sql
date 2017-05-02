
CREATE PROCEDURE [dbo].[sp_UpdateCompanyMaxDraw]
AS
BEGIN

truncate table CompanyMaxDraw

insert into CompanyMaxDraw(companyid,companyname,maxdraw)
select companyid,companyname,max(draw) as [max] from vHistoryEuropePan
where  draw > lose and draw > win and result = 1
group by companyname,companyid
END


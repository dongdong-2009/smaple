

CREATE PROCEDURE [dbo].[sp_delete_duplicate_forecast] 
AS
BEGIN

delete from Forecast where forecastid in (
select ForecastID from(
 select row_number() over (partition by matchid,Result,Score,Type,Description,TermIndex,Win,Draw,Lose,CompanyID,Remark,OldMatchID order by forecastid) as nid,ForecastID from Forecast 
 ) a
 where nid > 1
 )
 
  delete from Forecast where  Description like '%</div>    </div>    <!-- <div class="ts_yd">      <h2>阵容<br />点评</h2>%'
END



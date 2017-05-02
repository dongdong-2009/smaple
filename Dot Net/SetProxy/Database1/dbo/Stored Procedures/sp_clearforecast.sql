

CREATE PROCEDURE [dbo].[sp_clearforecast]     
AS    
BEGIN
declare @lastindex int    
select top 1 @lastindex = termindex from CurrentMatch order by TermIndex desc    
 delete from Forecast where type like '%球队概况%'  
 delete from Forecast where type like '%剧烈变化%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%【SP小于欧赔】%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%【反交叉盘】%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%不进球%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%不失球%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%连续进球%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%连续失球%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%上轮大败%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%上轮大胜%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%上轮%大败%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%上轮%大胜%' and TermIndex <>@lastindex     
 delete from Forecast where type like '%一周双赛%' and TermIndex <>@lastindex     
 delete from Forecast where type like '%连平%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%KeyPlayer%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%不进球%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%经典盘%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%平负相等%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%平均欧赔%' and TermIndex <>@lastindex       
 delete from Forecast where type like '%胜平相等%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%胜负相等%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%小球%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%大球%' and TermIndex <>@lastindex    
 delete from Forecast where type like '%未来赛事%' and TermIndex <>@lastindex   
 delete from Forecast where type like '%超低水%' and TermIndex <>@lastindex   
 delete from Forecast where type like 'a%' and TermIndex <>@lastindex   
 delete from Forecast where type like 'b%' and TermIndex <>@lastindex   
 delete from Forecast where type like '%上次交锋%' and TermIndex <>@lastindex   
 delete from Forecast where type like '%中比分%' and TermIndex <>@lastindex   
 delete from Forecast where type like '%密集%' and TermIndex <>@lastindex   
 delete from Forecast where type like '%盘口匹配%' and TermIndex <>@lastindex   
 delete from Forecast where type = '历史6连胜/负' and TermIndex <>@lastindex   
 delete from Forecast where type like '%弱弱%' and TermIndex <>@lastindex 
delete from Forecast where type like '%亚盘变化%' and TermIndex <>@lastindex 
delete from Forecast where type like '%初盘%' and TermIndex <>@lastindex 
delete from Forecast where type like '%连续升降%' and TermIndex <>@lastindex 
delete from Forecast where type like '%初始差异%' and TermIndex <>@lastindex 
delete from Forecast where type like '%赔率倒置%' and TermIndex <>@lastindex 
delete from Forecast where type like '%高SP%' and TermIndex <>@lastindex 
delete from Forecast where type like '%关键变化%' and TermIndex <>@lastindex 
delete from Forecast where type like '%返还率警戒线%' and TermIndex <>@lastindex 
delete from Forecast where type like '%比分特性%' and TermIndex <>@lastindex
delete from Forecast where type like '%交叉盘%' and TermIndex <>@lastindex 
delete from Forecast where type like '%ReturnRate%' and TermIndex <>@lastindex
delete from Forecast where type like '%历史%连%' and TermIndex <>@lastindex
delete from Forecast where type like '%144%' and TermIndex <>@lastindex
delete from Forecast where type like '%【冷】%' and TermIndex <>@lastindex
delete from Forecast where type like '%【胆】%' and TermIndex <>@lastindex
delete from NotesOkooo where IsDeleted = 1
 delete from Forecast where  Description like '%</div>    </div>    <!-- <div class="ts_yd">      <h2>阵容<br />点评</h2>%'
END   

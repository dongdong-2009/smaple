USE [BreakAwayContext]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_WebService_DataTable]    Script Date: 8/27/2016 1:45:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[sp_Get_WebService_DataTable] 
	@url nvarchar(500) = N'http://www.webxml.com.cn/WebServices/WeatherWS.asmx/',
	@fun nvarchar(500) = N'getRegionDataset',
	@par nvarchar(500) = N''
AS  
DECLARE @t TABLE(result nvarchar(max)) 
Declare @OBJ int,@HR int,@Status int,@Msg varchar(255),@Response nvarchar(4000)


exec @HR = sp_OACreate 'MSXML2.ServerXMLHttp',@OBJ OUT 
if @HR < 0  
begin     
	Raiserror('sp_OACreate MSXML2.ServerXMLHttp failed',16,1)       
	return   
end    
set @url = @url + @fun + '?' +@par
exec @HR = sp_OAMethod @obj, 'Open', NULL, 'POST', @url, false 
print @HR
if @HR <0  
begin     
	set @Msg = 'sp_OAMethod Open failed'       
	goto eh   
end    
exec @HR = sp_OAMethod @obj, 'send' 
print @HR
if @HR <0  
begin     
	set @Msg = 'sp_OAMethod Send failed'       
	goto eh   
end    
exec @HR = sp_OAGetProperty @obj, 'status', @status OUT 
if @HR <0  
begin     
	set @Msg = 'sp_OAMethod read status failed'        
	goto eh   
end
if @status <> 200  
begin     
	set @Msg = 'sp_OAMethod http status ' +str(@status)      
	goto eh   
end 
	   
INSERT INTO @t exec @HR = sp_OAGetProperty @obj, 'responseText'  

if @HR <0  
begin     
	set @Msg = 'sp_OAMethod read response failed'       
	goto eh   
end    
exec @HR = sp_OADestroy @obj 



DECLARE @Str_Cols nvarchar(max)
DECLARE @ReStr_All nvarchar(max)
DECLARE @ReStr_Cols nvarchar(max)
DECLARE @ReStr_Data nvarchar(max)

DECLARE  @xmls xml 
SELECT @ReStr_All = result  FROM @t
select * from @t 
return
 

SELECT @ReStr_Cols = substring (@ReStr_All,PATINDEX('%<xs:sequence>%',@ReStr_All)-1,len(@ReStr_All))
SELECT @ReStr_Cols = substring (@ReStr_Cols,0,PATINDEX('%</xs:complexType>%',@ReStr_Cols))
SELECT @ReStr_Cols = replace (@ReStr_Cols,'xs:','')
SELECT @ReStr_Cols = replace (@ReStr_Cols,'xmlns=""','')
SELECT @ReStr_Cols = replace (@ReStr_Cols,'diffgr:','')
SELECT @ReStr_Cols = replace (@ReStr_Cols,'msdata:','')
set  @xmls = @ReStr_Cols

---------------------------------------------------------------------
--<sequence><element name="ITEMTYPEID" >
--select S.value('(@name)[1]', 'NVARCHAR(100)') FROM @xmls.nodes('/sequence/element') T ( S )
select  @Str_Cols = isnull(@Str_Cols+',','') + 'T.c.value('''+'('+S.value('(@name)[1]', 'NVARCHAR(100)')+'/text())[1]'''+','+''''+'NVARCHAR(300)'''+') as '+S.value('(@name)[1]', 'NVARCHAR(100)')  FROM  @xmls.nodes('/sequence/element') T ( S )
---------------------------------------------------

SELECT @ReStr_Data = substring (@ReStr_All,PATINDEX('%<DataSet %',@ReStr_All)-1,len(@ReStr_All))

--SELECT @ReStr_Data = substring (@ReStr_Data,0,PATINDEX('%</DataSet>%',@ReStr_Data))

SELECT @ReStr_Data = replace (@ReStr_Data,'xmlns=""','')

SELECT @ReStr_Data = replace (@ReStr_Data,'diffgr:','')

SELECT @ReStr_Data = replace (@ReStr_Data,'msdata:','')

set @xmls = @ReStr_Data




declare @sqlStr nvarchar(max) = N'DECLARE @xmls XML=N''' + @ReStr_Data +''''
--select  @xmls = @sqlStr
--select @xmls
--return
declare  @ch nvarchar(max)  = cast(@xmls.query('/DataSet') as nvarchar(max))
select @ch as ch
return
select  @ch = SUBSTRING(@ch,2,PATINDEX('% id%',@ch)-1)
--select  @ch
SET @sqlStr = @sqlStr + 'SELECT '+ @Str_Cols + ' from @xmls.nodes('+'''/DataSet/*' +@ch + ''''+') AS T(c)'
exec(@sqlStr )

return   
eh:   
exec @HR = sp_OADestroy @obj   
Raiserror(@Msg, 16, 1)  
return
SELECT *  FROM @t 
--exec @HR = sp_OAMethod @obj, 'Open', NULL, 'GET', N'', false 


GO



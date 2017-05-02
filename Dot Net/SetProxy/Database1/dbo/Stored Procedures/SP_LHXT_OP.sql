CREATE PROCEDURE [dbo].[SP_LHXT_OP]  
  
AS  
BEGIN  

  truncate table LHXT_OP
  INSERT INTO [Football].[dbo].[LHXT_OP]  
           ([Win]  
           ,[Draw]  
           ,[Lose]  
           ,[MatchNumber]  
           ,[MatchID]  
           ,[TermIndex])  
     
  select [Win]  
           ,[Draw]  
           ,[Lose]  
           ,[MatchNumber]  
           ,[MatchID]  
           ,[TermIndex] from vCurrentEuropePan  where CompanyID =281 and pantype = '初盘'  
END  
  
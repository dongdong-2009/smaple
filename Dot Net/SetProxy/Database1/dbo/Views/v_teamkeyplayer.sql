
CREATE VIEW [dbo].v_teamkeyplayer
AS
select distinct matchid,  description = replace(  
 (select description as [data()] from v_teamkeyplayerTemp b where b.matchid=a.matchid  
 for xml path('')),' ','\r\n')  
 from v_teamkeyplayerTemp a


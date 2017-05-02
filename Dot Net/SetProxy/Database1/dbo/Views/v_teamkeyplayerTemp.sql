CREATE VIEW [dbo].[v_teamkeyplayerTemp]
AS
select distinct matchid,  description = '【' +hometeam+'】\r\n' + replace(  
 (select description as [data()] from v_hometeamkeyplayer b where b.hometeam=a.hometeam  
 for xml path('')),' ','\r\n') +'\r\n'
 from v_hometeamkeyplayer a
union all
select distinct matchid,  description = '【' +awayteam+'】\r\n' + replace(  
 (select description as [data()] from v_awayteamkeyplayer b where b.awayteam=a.awayteam  
 for xml path('')),' ','\r\n')  
 from v_awayteamkeyplayer a

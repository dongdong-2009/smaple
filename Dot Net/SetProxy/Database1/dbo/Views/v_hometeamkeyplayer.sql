CREATE VIEW [dbo].v_hometeamkeyplayer
AS
select matchid, b.team as hometeam, b.PlayerName +'('+ability+')' as description from currentmatch  a inner join TeamPlayerData b 
on a.hometeam = b.team 

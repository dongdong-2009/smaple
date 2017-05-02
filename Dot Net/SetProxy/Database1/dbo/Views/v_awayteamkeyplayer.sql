

CREATE VIEW [dbo].v_awayteamkeyplayer
AS
select matchid,  b.team as awayteam, b.PlayerName +'('+ability+')' as description from currentmatch  a inner join TeamPlayerData b 
on a.awayteam = b.team

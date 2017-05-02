

CREATE PROCEDURE [dbo].[ComputeLeagueHighScoreSPRate]

AS
BEGIN
	truncate table  LeagueHighScoreSP
	
	insert into LeagueHighScoreSP(LeagueName,missing,probability)
	select m.LeagueName,missing,probability from (
	select LeagueName,RowNo - RowNo_High as missing from (
	select MatchID,TermIndex,  LeagueName, ROW_NUMBER() over (partition by  leaguename order by matchtime desc,matchid desc) as RowNo from HistoryMatch
	) a inner join (
	select  MatchID,TermIndex, ROW_NUMBER() over (partition by  leaguename order by matchtime desc,matchid desc) as RowNo_High from HistoryMatch
	where ScoreSP >=78
	) b on 
	a.matchid = b.matchid and a.termindex = b.termindex
	where RowNo_High =1
	) m inner join
	(
	select a.LeagueName, ceiling(1.0*b.b/a.a) probability  from  (select LeagueName,COUNT(1) as a  from HistoryMatch where ScoreSP >= 78
	group by LeagueName) a
	inner join 
	(
	select LeagueName,COUNT(1) as b from HistoryMatch 
	group by LeagueName  
	) b
	on a.LeagueName = b.LeagueName
	) n
	on m.LeagueName = n.LeagueName

END


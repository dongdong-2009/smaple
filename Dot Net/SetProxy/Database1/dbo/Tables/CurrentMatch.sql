CREATE TABLE [dbo].[CurrentMatch] (
    [MatchID]       INT            NOT NULL,
    [TermIndex]     INT            NULL,
    [LeagueName]    VARCHAR (12)   NULL,
    [MatchTime]     DATETIME       NULL,
    [HomeTeam]      VARCHAR (20)   NULL,
    [AwayTeam]      VARCHAR (20)   NULL,
    [LetBall]       SMALLINT       NULL,
    [Win]           DECIMAL (5, 2) NULL,
    [Draw]          DECIMAL (5, 2) NULL,
    [Lose]          DECIMAL (5, 2) NULL,
    [SaleEndTime]   DATETIME       NULL,
    [MatchNumber]   SMALLINT       NULL,
    [Remark]        VARCHAR (800)  NULL,
    [MatchID_Okooo] INT            NULL,
    [MatchID_500]   INT            NULL,
    [IsJC]          BIT            CONSTRAINT [DF_CurrentMatch_IsJC] DEFAULT ((0)) NULL,
    CONSTRAINT [sqlite_autoindex_HistoryMatch_1_1] PRIMARY KEY CLUSTERED ([MatchID] ASC)
);


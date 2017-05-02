CREATE TABLE [dbo].[HistoryMatch] (
    [MatchID]       INT             NOT NULL,
    [TermIndex]     INT             NULL,
    [LeagueName]    VARCHAR (12)    NULL,
    [MatchTime]     DATETIME        NULL,
    [HomeTeam]      VARCHAR (20)    NULL,
    [AwayTeam]      VARCHAR (20)    NULL,
    [LetBall]       SMALLINT        NULL,
    [Score]         VARCHAR (5)     NULL,
    [ScoreSP]       DECIMAL (10, 2) NULL,
    [HalfScore]     VARCHAR (10)    NULL,
    [Win]           DECIMAL (5, 2)  NULL,
    [Draw]          DECIMAL (5, 2)  NULL,
    [Lose]          DECIMAL (5, 2)  NULL,
    [MatchSP]       DECIMAL (10, 2) NULL,
    [ScoreAmount]   SMALLINT        NULL,
    [ScoreAmountSP] DECIMAL (10, 2) NULL,
    [SaleEndTime]   DATETIME        NULL,
    [Result]        SMALLINT        NULL,
    [MatchNumber]   SMALLINT        NULL,
    [Remark]        VARCHAR (800)   NULL,
    CONSTRAINT [sqlite_autoindex_HistoryMatch_1] PRIMARY KEY CLUSTERED ([MatchID] ASC),
    CONSTRAINT [f_termindex] FOREIGN KEY ([TermIndex]) REFERENCES [dbo].[HistoryTerm] ([TermIndex]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [index_term]
    ON [dbo].[HistoryMatch]([TermIndex] ASC);


GO
CREATE NONCLUSTERED INDEX [index_leaguename]
    ON [dbo].[HistoryMatch]([LeagueName] ASC, [Win] ASC, [Draw] ASC, [Lose] ASC);


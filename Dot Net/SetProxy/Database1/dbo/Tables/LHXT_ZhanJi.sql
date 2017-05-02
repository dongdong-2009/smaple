CREATE TABLE [dbo].[LHXT_ZhanJi] (
    [ID]          INT IDENTITY (1, 1) NOT NULL,
    [HomeRound]   INT NULL,
    [HomePoints]  INT NULL,
    [GuestRound]  INT NULL,
    [GuestPoints] INT NULL,
    [MatchNumber] INT NULL,
    [MatchID]     INT NULL,
    [TermIndex]   INT NULL,
    [DiffPoint]   AS  ([HomePoints]-[GuestPoints]),
    CONSTRAINT [PK_LHXT_ZhanJi] PRIMARY KEY CLUSTERED ([ID] ASC)
);


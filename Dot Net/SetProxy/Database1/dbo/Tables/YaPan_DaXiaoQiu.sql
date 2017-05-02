CREATE TABLE [dbo].[YaPan_DaXiaoQiu] (
    [MatchId]     INT          NOT NULL,
    [YaPan]       VARCHAR (50) NULL,
    [DaxiaoQiu]   VARCHAR (50) NULL,
    [TermIndex]   INT          NULL,
    [MatchNumber] INT          NULL,
    [Remark]      VARCHAR (50) NULL,
    CONSTRAINT [PK_YaPan_DaXiaoQiu] PRIMARY KEY CLUSTERED ([MatchId] ASC)
);


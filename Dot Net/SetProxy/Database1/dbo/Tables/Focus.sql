CREATE TABLE [dbo].[Focus] (
    [ID]          INT IDENTITY (1, 1) NOT NULL,
    [MatchID]     INT NULL,
    [MatchNumber] INT NULL,
    [TermIndex]   INT NULL,
    CONSTRAINT [PK_Focus1] PRIMARY KEY CLUSTERED ([ID] ASC)
);


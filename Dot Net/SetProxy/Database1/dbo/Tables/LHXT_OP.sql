CREATE TABLE [dbo].[LHXT_OP] (
    [ID]          INT   IDENTITY (1, 1) NOT NULL,
    [Win]         MONEY NULL,
    [Draw]        MONEY NULL,
    [Lose]        MONEY NULL,
    [MatchNumber] INT   NULL,
    [MatchID]     INT   NULL,
    [TermIndex]   INT   NULL
);


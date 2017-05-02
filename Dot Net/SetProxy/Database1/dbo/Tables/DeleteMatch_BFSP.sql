CREATE TABLE [dbo].[DeleteMatch_BFSP] (
    [MatchNumber] INT          NOT NULL,
    [VS]          VARCHAR (28) NOT NULL,
    [SPF]         INT          NOT NULL,
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_DeleteMatch_BFSP_1] PRIMARY KEY CLUSTERED ([ID] ASC)
);


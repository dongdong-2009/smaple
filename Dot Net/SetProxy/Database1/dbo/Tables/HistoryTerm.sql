CREATE TABLE [dbo].[HistoryTerm] (
    [TermIndex] INT NOT NULL,
    [Completed] BIT NULL,
    CONSTRAINT [PK_HistoryTerm] PRIMARY KEY CLUSTERED ([TermIndex] ASC)
);


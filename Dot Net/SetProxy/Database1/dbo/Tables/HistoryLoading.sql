CREATE TABLE [dbo].[HistoryLoading] (
    [Termindex] INT NOT NULL,
    [EndAt]     INT CONSTRAINT [DF_HistoryLoading_EndAt] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_HistoryLoading] PRIMARY KEY CLUSTERED ([Termindex] ASC)
);


CREATE TABLE [dbo].[CurrentLoading] (
    [Termindex] INT NOT NULL,
    [EndAt]     INT CONSTRAINT [DF_CurrentLoading_EndAt] DEFAULT ((0)) NULL,
    [NextRound] INT CONSTRAINT [DF_CurrentLoading_NextRound] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_CurrentLoading] PRIMARY KEY CLUSTERED ([Termindex] ASC)
);


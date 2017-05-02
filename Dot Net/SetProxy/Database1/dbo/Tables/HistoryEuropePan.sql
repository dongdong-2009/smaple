CREATE TABLE [dbo].[HistoryEuropePan] (
    [PanID]         UNIQUEIDENTIFIER NOT NULL,
    [Win]           DECIMAL (8, 3)   NULL,
    [Draw]          DECIMAL (8, 3)   NULL,
    [Lose]          DECIMAL (8, 3)   NULL,
    [Win_UpOrDown]  INT              NULL,
    [Draw_UpOrDown] INT              NULL,
    [Lose_UpOrDown] INT              NULL,
    [ReturnRate]    DECIMAL (8, 3)   NULL,
    CONSTRAINT [PK__HistoryEuropePan__2E1BDC42] PRIMARY KEY CLUSTERED ([PanID] ASC),
    CONSTRAINT [f_panid_1] FOREIGN KEY ([PanID]) REFERENCES [dbo].[HistoryPan] ([PanID]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [index_wdl1]
    ON [dbo].[HistoryEuropePan]([Win] ASC, [Draw] ASC, [Lose] ASC);


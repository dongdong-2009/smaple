CREATE TABLE [dbo].[CurrentEuropePan] (
    [PanID]         UNIQUEIDENTIFIER NOT NULL,
    [Win]           DECIMAL (8, 3)   NULL,
    [Draw]          DECIMAL (8, 3)   NULL,
    [Lose]          DECIMAL (8, 3)   NULL,
    [Win_UpOrDown]  INT              NULL,
    [Draw_UpOrDown] INT              NULL,
    [Lose_UpOrDown] INT              NULL,
    [ReturnRate]    DECIMAL (8, 3)   NULL,
    CONSTRAINT [PK__CurrentEuropePan__182C9B23] PRIMARY KEY CLUSTERED ([PanID] ASC),
    CONSTRAINT [f_panid] FOREIGN KEY ([PanID]) REFERENCES [dbo].[CurrentPan] ([PanID]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [index_wdl]
    ON [dbo].[CurrentEuropePan]([Win] ASC, [Draw] ASC, [Lose] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_CurrentEuropePan_5_1509580416__K1_K4_K2_K3_K8]
    ON [dbo].[CurrentEuropePan]([PanID] ASC, [Lose] ASC, [Win] ASC, [Draw] ASC, [ReturnRate] ASC);


CREATE TABLE [dbo].[HistoryPan] (
    [PanID]           UNIQUEIDENTIFIER NOT NULL,
    [MatchID]         INT              NULL,
    [TermIndex]       INT              NULL,
    [CompanyID]       INT              NULL,
    [PanType]         VARCHAR (20)     NULL,
    [CreateTime]      DATETIME         NULL,
    [BeforeMatchTime] VARCHAR (30)     NULL,
    CONSTRAINT [sqlite_autoindex_HistoryPan_1] PRIMARY KEY CLUSTERED ([PanID] ASC),
    CONSTRAINT [f_companyid_4] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Company] ([CompanyID]) ON DELETE SET NULL ON UPDATE SET NULL,
    CONSTRAINT [f_matchid_3] FOREIGN KEY ([MatchID]) REFERENCES [dbo].[HistoryMatch] ([MatchID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_HistoryPan_HistoryTerm] FOREIGN KEY ([TermIndex]) REFERENCES [dbo].[HistoryTerm] ([TermIndex])
);


GO
CREATE NONCLUSTERED INDEX [index_companyid]
    ON [dbo].[HistoryPan]([CompanyID] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_HistoryPan_5_645577338__K5_K4_K3_K2_K1]
    ON [dbo].[HistoryPan]([PanType] ASC, [CompanyID] ASC, [TermIndex] ASC, [MatchID] ASC, [PanID] ASC);


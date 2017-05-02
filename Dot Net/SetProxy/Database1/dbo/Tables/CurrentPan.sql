CREATE TABLE [dbo].[CurrentPan] (
    [PanID]           UNIQUEIDENTIFIER NOT NULL,
    [MatchID]         INT              NOT NULL,
    [TermIndex]       INT              NULL,
    [CompanyID]       INT              NULL,
    [PanType]         VARCHAR (20)     NULL,
    [CreateTime]      DATETIME         NULL,
    [BeforeMatchTime] VARCHAR (30)     NULL,
    CONSTRAINT [PK__CurrentPan__15502E78] PRIMARY KEY CLUSTERED ([PanID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [index_company]
    ON [dbo].[CurrentPan]([CompanyID] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_CurrentPan_5_1925581898__K5_K2_K3_K4_K1_K6]
    ON [dbo].[CurrentPan]([PanType] ASC, [MatchID] ASC, [TermIndex] ASC, [CompanyID] ASC, [PanID] ASC, [CreateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_CurrentPan_5_1925581898__K2_K4_K3_K5_K1_K6]
    ON [dbo].[CurrentPan]([MatchID] ASC, [CompanyID] ASC, [TermIndex] ASC, [PanType] ASC, [PanID] ASC, [CreateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_CurrentPan_5_1925581898__K2_K3_K4_K1_K5_K6]
    ON [dbo].[CurrentPan]([MatchID] ASC, [TermIndex] ASC, [CompanyID] ASC, [PanID] ASC, [PanType] ASC, [CreateTime] ASC);


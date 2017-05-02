CREATE TABLE [dbo].[CurrentAsiaPan] (
    [PanID]           UNIQUEIDENTIFIER NOT NULL,
    [Win]             DECIMAL (8, 3)   NULL,
    [Lose]            DECIMAL (8, 3)   NULL,
    [Win_UpOrDown]    INT              NULL,
    [Lose_UpOrDown]   INT              NULL,
    [PanKou]          VARCHAR (20)     NULL,
    [MatchID]         INT              NULL,
    [TermIndex]       INT              NULL,
    [CompanyID]       INT              NULL,
    [PanType]         VARCHAR (20)     NULL,
    [CreateTime]      DATETIME         NULL,
    [BeforeMatchTime] VARCHAR (30)     NULL,
    CONSTRAINT [PK_CurrentAsiaPan] PRIMARY KEY CLUSTERED ([PanID] ASC),
    CONSTRAINT [FK_CurrentAsiaPan_AsiaCompany] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[AsiaCompany] ([CompanyID])
);


GO
CREATE NONCLUSTERED INDEX [IX_CurrentAsiaPan]
    ON [dbo].[CurrentAsiaPan]([PanID] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_CurrentAsiaPan_5_1637580872__K9_K2_K3_K7_K8_6]
    ON [dbo].[CurrentAsiaPan]([CompanyID] ASC, [Win] ASC, [Lose] ASC, [MatchID] ASC, [TermIndex] ASC)
    INCLUDE([PanKou]);


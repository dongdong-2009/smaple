CREATE TABLE [dbo].[HistoryAsiaPan] (
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
    CONSTRAINT [PK_HistoryAsiaPan] PRIMARY KEY CLUSTERED ([PanID] ASC),
    CONSTRAINT [FK_HistoryAsiaPan_AsiaCompany] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[AsiaCompany] ([CompanyID])
);


CREATE TABLE [dbo].[Forecast] (
    [ForecastID]      INT            IDENTITY (1, 1) NOT NULL,
    [MatchID]         INT            NULL,
    [Result]          CHAR (1)       NULL,
    [Score]           VARCHAR (5)    NULL,
    [Type]            VARCHAR (50)   NULL,
    [BeforeMatchTime] VARCHAR (40)   NULL,
    [Description]     VARCHAR (MAX)  NULL,
    [IsCorrect]       CHAR (1)       NULL,
    [TermIndex]       INT            NULL,
    [Win]             DECIMAL (5, 2) NULL,
    [Draw]            DECIMAL (5, 2) NULL,
    [Lose]            DECIMAL (5, 2) NULL,
    [CompanyID]       INT            NULL,
    [OldMatchID]      INT            NULL,
    [Remark]          VARCHAR (100)  NULL,
    CONSTRAINT [PK__Forecast__1B0907CE] PRIMARY KEY CLUSTERED ([ForecastID] ASC)
);


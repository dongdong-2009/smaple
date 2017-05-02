CREATE TABLE [dbo].[CompanyMaxDraw] (
    [CompanyID]   INT          NOT NULL,
    [CompanyName] VARCHAR (50) NOT NULL,
    [MaxDraw]     SMALLMONEY   NOT NULL,
    CONSTRAINT [PK_CompanyMaxDraw] PRIMARY KEY CLUSTERED ([CompanyID] ASC)
);


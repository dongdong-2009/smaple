CREATE TABLE [dbo].[AsiaCompany] (
    [CompanyID]   INT           NOT NULL,
    [CompanyName] VARCHAR (20)  NULL,
    [Remark]      VARCHAR (300) NULL,
    CONSTRAINT [sqlite_autoindex_AsiaCompany_1] PRIMARY KEY CLUSTERED ([CompanyID] ASC)
);


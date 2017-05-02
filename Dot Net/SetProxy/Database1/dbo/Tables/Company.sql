CREATE TABLE [dbo].[Company] (
    [CompanyID]   INT           NOT NULL,
    [CompanyName] VARCHAR (20)  NULL,
    [Remark]      VARCHAR (300) NULL,
    CONSTRAINT [sqlite_autoindex_Company_1] PRIMARY KEY CLUSTERED ([CompanyID] ASC)
);


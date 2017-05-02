CREATE TABLE [dbo].[ClassicPan] (
    [PanID]       UNIQUEIDENTIFIER NOT NULL,
    [CompanyID]   INT              NULL,
    [Win]         DECIMAL (5, 2)   NULL,
    [Draw]        DECIMAL (5, 2)   NULL,
    [Lose]        DECIMAL (5, 2)   NULL,
    [Description] VARCHAR (200)    NULL,
    CONSTRAINT [sqlite_autoindex_ClassicPan_1] PRIMARY KEY CLUSTERED ([PanID] ASC),
    CONSTRAINT [FK_ClassicPan_Company] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Company] ([CompanyID]) ON DELETE CASCADE ON UPDATE CASCADE
);


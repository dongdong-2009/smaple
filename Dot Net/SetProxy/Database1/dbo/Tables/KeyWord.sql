CREATE TABLE [dbo].[KeyWord] (
    [ID]  INT           IDENTITY (1, 1) NOT NULL,
    [Tag] NVARCHAR (20) NULL,
    CONSTRAINT [PK_KeyWord] PRIMARY KEY CLUSTERED ([ID] ASC)
);


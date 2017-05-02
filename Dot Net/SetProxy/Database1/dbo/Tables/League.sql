CREATE TABLE [dbo].[League] (
    [lid]        INT          NOT NULL,
    [LeagueName] VARCHAR (20) NOT NULL,
    [TeamCount]  SMALLINT     NULL,
    CONSTRAINT [PK_League] PRIMARY KEY CLUSTERED ([lid] ASC)
);


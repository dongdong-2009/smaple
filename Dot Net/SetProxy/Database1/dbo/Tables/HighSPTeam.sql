CREATE TABLE [dbo].[HighSPTeam] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [leaguename] VARCHAR (12) NULL,
    [teamname]   VARCHAR (12) NULL,
    CONSTRAINT [PK_HighSPTeam] PRIMARY KEY CLUSTERED ([id] ASC)
);


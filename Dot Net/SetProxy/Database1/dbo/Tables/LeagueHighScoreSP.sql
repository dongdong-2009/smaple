CREATE TABLE [dbo].[LeagueHighScoreSP] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [LeagueName]  VARCHAR (50) NULL,
    [Missing]     INT          NULL,
    [Probability] INT          NULL,
    CONSTRAINT [PK_LeagueHighScoreSP] PRIMARY KEY CLUSTERED ([ID] ASC)
);


CREATE TABLE [dbo].[TeamPlayerData] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [lid]        INT          NULL,
    [Team]       VARCHAR (20) NULL,
    [PlayerName] VARCHAR (20) NULL,
    [Ability]    VARCHAR (50) NULL,
    CONSTRAINT [PK_TeamPlayerData] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_TeamPlayerData_5_1858105660__K3_4_5]
    ON [dbo].[TeamPlayerData]([Team] ASC)
    INCLUDE([PlayerName], [Ability]);


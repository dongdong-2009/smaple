CREATE TABLE [dbo].[Team_Information] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [teamname]    VARCHAR (558) NULL,
    [description] VARCHAR (MAX) NULL,
    [auto]        BIT           CONSTRAINT [DF_Team_Information_auto] DEFAULT ((0)) NULL,
    [createtime]  DATETIME      NULL,
    [termindex]   VARCHAR (50)  NULL,
    [comment]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Team_Information] PRIMARY KEY CLUSTERED ([id] ASC)
);


CREATE TABLE [dbo].[NotesOkooo] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [user_name]   NVARCHAR (50)  NULL,
    [content]     NVARCHAR (MAX) NULL,
    [add_time]    DATETIME       NULL,
    [match_id]    INT            NULL,
    [termindex]   INT            NULL,
    [matchnumber] INT            NULL,
    [IsDeleted]   BIT            NULL,
    CONSTRAINT [PK_NotesOkooo] PRIMARY KEY CLUSTERED ([ID] ASC)
);


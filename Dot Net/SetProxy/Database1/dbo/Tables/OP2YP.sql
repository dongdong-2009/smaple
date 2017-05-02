CREATE TABLE [dbo].[OP2YP] (
    [ID]     INT           IDENTITY (1, 1) NOT NULL,
    [OP]     MONEY         NULL,
    [SWL]    MONEY         NULL,
    [PanKou] NVARCHAR (20) NULL,
    [SWR]    AS            ((1.85)-[SWL]),
    CONSTRAINT [PK_OP2YP] PRIMARY KEY CLUSTERED ([ID] ASC)
);


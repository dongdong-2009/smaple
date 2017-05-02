CREATE TABLE [dbo].[ReturnRate] (
    [companyid]       INT             NOT NULL,
    [leaguename]      NVARCHAR (20)   NULL,
    [begin_maxreturn] DECIMAL (18, 2) NULL,
    [begin_minreturn] DECIMAL (18, 2) NULL,
    [end_maxreturn]   DECIMAL (18, 2) NULL,
    [end_minreturn]   DECIMAL (18, 2) NULL,
    [begin_avgreturn] DECIMAL (18, 2) NULL
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_ReturnRate_5_110623437__K1_K2_K3]
    ON [dbo].[ReturnRate]([companyid] ASC, [leaguename] ASC, [begin_maxreturn] ASC);


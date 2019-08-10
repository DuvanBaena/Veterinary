CREATE TABLE [dbo].[TblServiceType] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TblServiceType] PRIMARY KEY CLUSTERED ([Id] ASC)
);


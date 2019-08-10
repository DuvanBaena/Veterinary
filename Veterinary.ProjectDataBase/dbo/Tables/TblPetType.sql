CREATE TABLE [dbo].[TblPetType] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TblPetType] PRIMARY KEY CLUSTERED ([Id] ASC)
);


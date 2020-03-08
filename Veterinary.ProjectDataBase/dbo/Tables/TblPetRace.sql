CREATE TABLE [dbo].[TblPetRace] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TblPetRace] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[TblAgenda]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [Name] VARBINARY(50) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Remarks] VARCHAR(50) NULL, 
    [IsAvailable] BIT NOT NULL,
	[OwnerId] INT NULL, 
    [PetId] INT NULL, 
    CONSTRAINT [PK_TblAgenda] PRIMARY KEY CLUSTERED ([Id] ASC),		
	CONSTRAINT [Fk_TblAgenda_Owner] FOREIGN KEY ([OwnerId]) REFERENCES [TblOwner] (Id),
	CONSTRAINT [Fk_TblAgenda_Pet] FOREIGN KEY ([PetId]) REFERENCES [TblPet] (Id)
)

CREATE TABLE [dbo].[TblHistory]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,  
    [Description] VARCHAR(MAX) NULL, 
    [Date] DATETIME NULL, 
    [Remarks] VARCHAR(MAX) NOT NULL, 
    [PetId] INT NULL,

	CONSTRAINT [Pk_TblHistory] PRIMARY KEY CLUSTERED ([Id] ASC),		
	CONSTRAINT [Fk_TblHistory_Pet] FOREIGN KEY ([PetId]) REFERENCES [TblPet] (Id)


)

﻿CREATE TABLE [dbo].[TblPet]
(
	[Id] INT  IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [ImageUrl] NVARCHAR(MAX) NULL, 
    [Race] NVARCHAR(50) NULL, 
    [Born] DATETIME NOT NULL, 
    [Remarks] NVARCHAR(MAX) NULL, 
    [PetTypeId] INT NOT NULL,

	CONSTRAINT [PK_Pet] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [Fk_Pet_PetType] FOREIGN KEY ([PetTypeId]) REFERENCES [TblPetType] (Id)

)

﻿CREATE TABLE [dbo].[TblPetSex]
(
	[Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TblPetSex] PRIMARY KEY CLUSTERED ([Id] ASC)
)

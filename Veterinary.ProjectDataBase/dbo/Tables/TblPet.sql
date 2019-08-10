CREATE TABLE [dbo].[TblPet] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50)  NOT NULL,
    [ImageUrl]  NVARCHAR (MAX) NULL,
    [Race]      NVARCHAR (50)  NULL,
    [Born]      DATETIME2 (7)  NOT NULL,
    [Remarks]   NVARCHAR (MAX) NULL,
    [PetTypeId] INT            NULL,
    [OwnerId]   INT            NULL,
    CONSTRAINT [PK_TblPet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TblPet_TblOwner_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[TblOwner] ([Id]),
    CONSTRAINT [FK_TblPet_TblPetType_PetTypeId] FOREIGN KEY ([PetTypeId]) REFERENCES [dbo].[TblPetType] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TblPet_OwnerId]
    ON [dbo].[TblPet]([OwnerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TblPet_PetTypeId]
    ON [dbo].[TblPet]([PetTypeId] ASC);


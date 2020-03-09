CREATE TABLE [dbo].[TblPet] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [ImageUrl]     NVARCHAR (50)  NULL,
    [Born]         DATETIME2 (7)  NOT NULL,
    [Remarks]      NVARCHAR (MAX) NULL,
    [Age]          INT            NOT NULL,
    [Reproductive] NVARCHAR (MAX) NULL,
    [Food]         NVARCHAR (MAX) NULL,
    [Color]        NVARCHAR (MAX) NULL,
    [Frequency]    NVARCHAR (MAX) NULL,
    [PetSexId]     INT            NULL,
    [PetTypeId]    INT            NULL,
    [PetRaceId]    INT            NULL,
    [OwnerId]      INT            NULL,
    CONSTRAINT [PK_TblPet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TblPet_TblOwner_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[TblOwner] ([Id]),
    CONSTRAINT [FK_TblPet_TblPetRace_PetRaceId] FOREIGN KEY ([PetRaceId]) REFERENCES [dbo].[TblPetRace] ([Id]),
    CONSTRAINT [FK_TblPet_TblPetSex_PetSexId] FOREIGN KEY ([PetSexId]) REFERENCES [dbo].[TblPetSex] ([Id]),
    CONSTRAINT [FK_TblPet_TblPetType_PetTypeId] FOREIGN KEY ([PetTypeId]) REFERENCES [dbo].[TblPetType] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TblPet_OwnerId]
    ON [dbo].[TblPet]([OwnerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TblPet_PetRaceId]
    ON [dbo].[TblPet]([PetRaceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TblPet_PetSexId]
    ON [dbo].[TblPet]([PetSexId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TblPet_PetTypeId]
    ON [dbo].[TblPet]([PetTypeId] ASC);


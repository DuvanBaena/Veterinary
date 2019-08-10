CREATE TABLE [dbo].[TblAgenda] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Date]        DATETIME2 (7)  NOT NULL,
    [Remarks]     NVARCHAR (MAX) NULL,
    [IsAvailable] BIT            NOT NULL,
    [OwnerId]     INT            NULL,
    [PetId]       INT            NULL,
    CONSTRAINT [PK_TblAgenda] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TblAgenda_TblOwner_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[TblOwner] ([Id]),
    CONSTRAINT [FK_TblAgenda_TblPet_PetId] FOREIGN KEY ([PetId]) REFERENCES [dbo].[TblPet] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TblAgenda_OwnerId]
    ON [dbo].[TblAgenda]([OwnerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TblAgenda_PetId]
    ON [dbo].[TblAgenda]([PetId] ASC);


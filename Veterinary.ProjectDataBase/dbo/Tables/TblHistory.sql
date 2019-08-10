CREATE TABLE [dbo].[TblHistory] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Description]   NVARCHAR (100) NOT NULL,
    [Date]          DATETIME2 (7)  NOT NULL,
    [Remarks]       NVARCHAR (MAX) NULL,
    [ServiceTypeId] INT            NULL,
    [PetId]         INT            NULL,
    CONSTRAINT [PK_TblHistory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TblHistory_TblPet_PetId] FOREIGN KEY ([PetId]) REFERENCES [dbo].[TblPet] ([Id]),
    CONSTRAINT [FK_TblHistory_TblServiceType_ServiceTypeId] FOREIGN KEY ([ServiceTypeId]) REFERENCES [dbo].[TblServiceType] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TblHistory_PetId]
    ON [dbo].[TblHistory]([PetId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TblHistory_ServiceTypeId]
    ON [dbo].[TblHistory]([ServiceTypeId] ASC);


CREATE TABLE [dbo].[TblOwner] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [UserId] NVARCHAR (450) NULL,
    CONSTRAINT [PK_TblOwner] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TblOwner_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TblOwner_UserId]
    ON [dbo].[TblOwner]([UserId] ASC);


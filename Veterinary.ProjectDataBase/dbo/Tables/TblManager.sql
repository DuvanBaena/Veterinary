CREATE TABLE [dbo].[TblManager] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [UserId] NVARCHAR (450) NULL,
    CONSTRAINT [PK_TblManager] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TblManager_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TblManager_UserId]
    ON [dbo].[TblManager]([UserId] ASC);

